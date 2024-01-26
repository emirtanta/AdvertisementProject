using AdvertisementProject.Common;
using AdvertisementProject.Dtos.AppRoleDtos;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IAppUserService:IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        /// <summary>
        /// kullanıcıları rollerine göre oluşturur
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<IResponse<AppUserCreateDto>> CreateWithRoleServiceAsync(AppUserCreateDto dto, int roleId);

        /// <summary>
        /// giriş yapan kullanıcıların kontrolünü sağlar
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<IResponse<AppUserListDto>> CheckUserServiceAsync(AppUserLoginDto dto);

        /// <summary>
        /// kullanıcıların id değerine göre bulundukları rollerin listesini getirir
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdServiceAsync(int userId); 
    }
}
