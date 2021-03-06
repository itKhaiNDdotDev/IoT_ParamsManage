using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EFConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Users");
            builder.Property(t => t.fullname).IsRequired(true).HasMaxLength(50).IsUnicode(true);
            builder.Property(t => t.is_active).IsRequired(true).HasDefaultValue(true);
            builder.Property(t => t.is_admin).IsRequired().HasDefaultValue(false);
            builder.Property(t => t.create_date).IsRequired(true).HasDefaultValue(DateTime.Now.Date);
        }
    }
}
