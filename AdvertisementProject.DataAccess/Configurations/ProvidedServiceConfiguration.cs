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
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(x => x.Description)
                .HasColumnType("nvarchar");

            builder.Property(x => x.ImagePath)
                .HasMaxLength(1000);

            builder.Property(x=>x.Title)
                .HasMaxLength(50)
                .IsRequired();

            //CreateDate alanına sql üzerinden günün tarihi değeri ataması
            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
