using IoTWebAPI.EF;
using IoTWebAPI.Models;
using IoTWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(s => 
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "Test API",
                    Description = "Test IoT API with Swagger Ui"
                });    
            });

            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001//*",
                                            "https://localhost:44332/*,",
                                            "http://localhost:5000",
                                            "http://localhost",
                                            "https://localhost",
                                            "https://localhost:80",
                                            "https://localhost:443",
                                            "http://localhost:80",
                                            "http://localhost:443",
                                            "http://localhost:22",
                                            "https://localhost:22"
                                            );
                    });
            });

            services.AddDbContext<IoTDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DraftIoTDb")));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IoTDbContext>()
                .AddDefaultTokenProviders();
            //My DI
            services.AddTransient<IDevices, DeviceManage>();
            services.AddTransient<IDvAttributes, DvAttributesManage>();
            services.AddTransient<IDvAtbDatas, DataService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IUsers, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAPI");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
