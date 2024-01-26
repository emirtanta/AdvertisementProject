using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.GenderDtos;
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
    public class GenderService:Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderService
    {
        public GenderService(IMapper mapper,IValidator<GenderCreateDto> createDtoValidator,IValidator<GenderUpdateDto> updateDtoValidator,IUow uow):base(mapper,uow,createDtoValidator,updateDtoValidator)
        {
            
        }
    }
}
