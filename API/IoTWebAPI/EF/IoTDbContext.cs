using IoTWebAPI.EFConfigurations;
using IoTWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EF
{
    public class IoTDbContext : IdentityDbContext<User, Role, int>
    {
        public IoTDbContext(/*[NotNullAttribute] */DbContextOptions options) : base(options)
        {
        }

        //protected override void Configuring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new DeviceConfig());
            modelBuilder.ApplyConfiguration(new DvAttributeConfig());
            modelBuilder.ApplyConfiguration(new DataConfig());

            //Identity
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(i => i.UserId);
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DvAttribute> DvAttributes { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}
