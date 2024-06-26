﻿using AdvertisementProject.Business.Extensions;
using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.Interfaces;
using AdvertisementProject.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdvertisementProject.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;

        public Service(IMapper mapper, IUow uow, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CreateDto>> CreateServiceAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangeAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllServiceAsync()
        {
            var data=await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);

            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<IDto>> GetByIdServiceAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x=>x.Id==id);

            if (data==null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} değerine sahip kayıt bulunamadı");
            }

            var dto=_mapper.Map<IDto>(data);

            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveServiceAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);

            if (data==null)
            {
                return new Response(ResponseType.NotFound, $"{id} değerine sahip veri bulunamadı");
            }

            _uow.GetRepository<T>().Remove(data);

            await _uow.SaveChangeAsync();

            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateServiceAsync(UpdateDto dto)
        {
            var result=_updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var unchangeData = await _uow.GetRepository<T>().FindAsync(dto.Id);

                if(unchangeData==null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} değerine ait bir kayıt bulunamadı");
                }

                var entity = _mapper.Map<T>(dto);

                _uow.GetRepository<T>().Update(entity, unchangeData);

                await _uow.SaveChangeAsync();

                return new Response<UpdateDto>(ResponseType.Success, dto);
            }

            return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}
