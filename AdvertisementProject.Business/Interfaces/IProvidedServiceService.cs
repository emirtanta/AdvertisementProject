using AdvertisementProject.Business.Services;
using AdvertisementProject.Dtos.ProvidedServiceDtos;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
    }
}
