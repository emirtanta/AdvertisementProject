using AdvertisementProject.Dtos.ProvidedServiceDtos;
using AdvertisementProject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Mapping.AutoMapper
{
    public class ProvidedServiceProfile:Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceListDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceCreateDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedService>().ReverseMap();
        }
    }
}
