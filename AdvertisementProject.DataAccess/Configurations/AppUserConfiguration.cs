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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Firstname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x=>x.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x=>x.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x=>x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x=>x.Password)
                .HasMaxLength(50)
                .IsRequired();

            //Gender ile AppUser arasındaki yabancı anahtar tanımlaması
            builder.HasOne(x => x.Gender)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.GenderId);
        }
    }
}
