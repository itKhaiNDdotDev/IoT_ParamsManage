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
            builder.ToTable("User");
            builder.HasKey(i => i.u_id);
            builder.Property(t => t.fullname).IsRequired(true).HasMaxLength(60).IsUnicode(true);
            builder.HasIndex(t => t.email).IsUnique(true);
            builder.Property(t => t.password).IsRequired(true).IsUnicode(false);
            builder.Property(t => t.is_active).IsRequired(true).HasDefaultValue(1);
            builder.Property(t => t.create_time).IsRequired(true).HasDefaultValue(DateTime.Now);
        }
    }
}
