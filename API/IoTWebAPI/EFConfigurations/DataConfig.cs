using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.EFConfigurations
{
    public class DataConfig : IEntityTypeConfiguration<Data>
    {
        public void Configure(EntityTypeBuilder<Data> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Datas");
            builder.HasKey(i => i.id);
            builder.Property(t => t.value).IsRequired(true);
            builder.Property(t => t.update_time).IsRequired(true).HasDefaultValue(DateTime.Now);
            builder.HasOne(v => v.dv_attribute).WithMany(a => a.data_values).HasForeignKey(fk => fk.a_id);
        }
    }
}
