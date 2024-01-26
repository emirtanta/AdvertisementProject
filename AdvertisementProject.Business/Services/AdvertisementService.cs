using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using AdvertisementProject.Dtos.AdvertisementDtos;
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
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper,uow,createDtoValidator,updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesServiceAsync()
        {
            var data = await _uow.GetRepository<Advertisement>()
                .GetAllAsync(x => x.Status, x => x.CreateDate, Common.Enums.OrderByType.DESC);

            var dto = _mapper.Map<List<AdvertisementListDto>>(data);

            return new Response<List<AdvertisementListDto>>(ResponseType.Success,dto);
        }
    }
}
