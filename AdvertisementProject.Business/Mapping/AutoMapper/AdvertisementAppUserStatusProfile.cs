using AdvertisementProject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Mapping.AutoMapper
{
    public class AdvertisementAppUserStatusProfile:Profile
    {
        public AdvertisementAppUserStatusProfile()
        {
            CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusProfile>().ReverseMap();
        }
    }
}
