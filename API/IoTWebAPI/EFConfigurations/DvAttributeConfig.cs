using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EFConfigurations
{
    public class DvAttributeConfig : IEntityTypeConfiguration<DvAttribute>
    {
        public void Configure(EntityTypeBuilder<DvAttribute> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Attributes");
            builder.HasKey(i => i.a_id);
            builder.Property(t => t.a_name).IsRequired(true);
            builder.Property(t => t.a_description).HasMaxLength(255).IsUnicode(true);
            builder.Property(t => t.is_active).IsRequired(true).HasDefaultValue(0);
            builder.Property(t => t.create_date).IsRequired(true).HasDefaultValue(DateTime.Now.Date);
            builder.Property(t => t.last_update).IsRequired(false);
            builder.HasOne(a => a.device).WithMany(d => d.list_attributes).HasForeignKey(fk => fk.d_id);
        }
    }
}
