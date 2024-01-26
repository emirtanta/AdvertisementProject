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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition)
                .HasMaxLength(50)
                .IsRequired();

            //AppRole için veritabanına tablolar aktarılırken iki adet rol eklemesi yapıldı
            builder.HasData(new AppRole[]
            {
                new()
                {
                    Id=1,
                    Definition="Admin"
                },
                new()
                {
                    Id=2,
                    Definition="Member"
                }
            });
        }
    }
}
