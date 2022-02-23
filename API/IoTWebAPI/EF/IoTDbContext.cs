using IoTWebAPI.EFConfigurations;
using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EF
{
    public class IoTDbContext : DbContext
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
            modelBuilder.ApplyConfiguration(new DeviceConfig());
            modelBuilder.ApplyConfiguration(new DvAttributeConfig());
            modelBuilder.ApplyConfiguration(new DataConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DvAttribute> DvAttributes { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}
