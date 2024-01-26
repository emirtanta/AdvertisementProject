using AdvertisementProject.Business.Extensions;
using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common;
using AdvertisementProject.Common.Enums;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using AdvertisementProject.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _creteDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> creteDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _creteDtoValidator = creteDtoValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAdvertisementServiceAsync(AdvertisementAppUserCreateDto dto)
        {
            var result=_creteDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId==dto.AdvertisementId);

                if (control==null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);

                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);

                    await _uow.SaveChangeAsync();

                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new List<CustomValidationError>
                {
                    new CustomValidationError
                    {
                        ErrorMessage="Daha önce başvurulan ilana başvurulamaz",PropertyName=""
                    }
                };

                return new Response<AdvertisementAppUserCreateDto>(dto,errors);
            }

            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetListAdvertisementServiceAsync(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query
                .Include(x => x.Advertisement)
                .Include(x => x.AdvertisemenAppUserStatus)
                .Include(x => x.MilitaryStatus)
                .Include(x => x.AppUser)
                .ThenInclude(x => x.Gender)
                .Where(x => x.AdvertisementAppUserStatusId == (int)type)
                .ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId=(int)type;

            await _uow.SaveChangeAsync();
        }
    }
}
