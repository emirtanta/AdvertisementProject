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
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new 
            {
                x.AppRoleId,
                x.AppUserId
            }).IsUnique();

            //AppRole ile AppUserRole arasındaki yabancı anahtar tanımı
            builder.HasOne(x => x.AppRole)
                .WithMany(x => x.AppUserRoles)
                .HasForeignKey(x => x.AppRoleId);

            //AppUser ile AppUserRoles arasındaki yabancı anahtar tanımı
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.AppUserRoles)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
