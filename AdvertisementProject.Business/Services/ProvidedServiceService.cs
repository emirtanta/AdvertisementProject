using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.ProvidedServiceDtos;
using AdvertisementProject.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUow uow) : base(mapper, uow, createDtoValidator, updateDtoValidator )
        {
        }

    }
}
