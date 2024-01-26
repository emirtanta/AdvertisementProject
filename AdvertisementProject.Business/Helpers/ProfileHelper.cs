using AdvertisementProject.Business.Mapping.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile(),
            };
        }
    }
}
