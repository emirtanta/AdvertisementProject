using AdvertisementProject.Business.Extensions;
using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.AppRoleDtos;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper,uow,createDtoValidator,updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserListDto>> CheckUserServiceAsync(AppUserLoginDto dto)
        {
            var validationResult=_loginDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>()
                    .GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);

                return new Response<AppUserListDto>(ResponseType.NotFound, "Kllanıcı adı veya şifre hatalı");
            }

            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleServiceAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult=_createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                await _uow.GetRepository<AppUser>().CreateAsync(user);

                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });

                await _uow.SaveChangeAsync();

                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }

            return new Response<AppUserCreateDto>(dto,validationResult.ConvertToCustomValidationError());   
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdServiceAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "ilgili rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);

        }
    }
}
