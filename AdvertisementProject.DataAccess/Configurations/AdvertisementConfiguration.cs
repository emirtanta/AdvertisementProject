using AdvertisementProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.DataAccess.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            //Description özelliğinin sql'deki tipi ayarlandı
            builder.Property(x => x.Description)
                .HasColumnType("nvarchar")
                .IsRequired();

            //CreateDate alanına sql'de varsayılan olarak günün tarihi değeri ataması yapıldı
            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
