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
    internal class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x => new 
            {
                x.AdvertisementId,
                x.AppUserId
            }).IsUnique();

            builder.Property(x=>x.CvPath)
                .HasMaxLength(1000)
                .IsRequired();

            //Advertisement ile AdvertisementAppUsers arasındaki Yabancı anahtar tanımı
            builder.HasOne(x=>x.Advertisement)
                .WithMany(x=>x.AdvertisementAppUsers)
                .HasForeignKey(x=>x.AdvertisementId);

            //Advertisement ile AdvertisementAppUsers arasındaki Yabancı anahtar tanımı
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.AppUserId);

            //AdvertisemenAppUserStatus ile AdvertisementAppUsers arasındaki Yabancı anahtar tanımı
            builder.HasOne(x => x.AdvertisemenAppUserStatus)
                .WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.AdvertisementAppUserStatusId);

            //MilitaryStatus ile AdvertisementAppUsers arasındaki Yabancı anahtar tanımı
            builder.HasOne(x => x.MilitaryStatus)
                .WithMany(x => x.AdvertisementAppUsers)
                .HasForeignKey(x => x.MilitaryStatusId);
        }
    }
}
