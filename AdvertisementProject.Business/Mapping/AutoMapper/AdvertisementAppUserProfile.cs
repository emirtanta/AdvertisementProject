using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using AdvertisementProject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Mapping.AutoMapper
{
    public class AdvertisementAppUserProfile:Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
        }
    }
}
