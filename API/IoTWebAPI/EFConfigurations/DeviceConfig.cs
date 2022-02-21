using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EFConfigurations
{
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Devices");
            builder.HasKey(i => i.d_id);
            builder.Property(t => t.device_name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
            builder.Property(t => t.device_description).HasMaxLength(350).IsUnicode(true);
            builder.Property(t => t.img_url).IsUnicode(false);
            builder.Property(t => t.is_active).IsRequired(true).HasDefaultValue(1);
            builder.Property(t => t.create_date).IsRequired(true).HasDefaultValue(DateTime.Now.Date);
            builder.HasOne(d => d.owner).WithMany(u => u.my_devices).HasForeignKey(fk => fk.u_id);
        }
    }
}
