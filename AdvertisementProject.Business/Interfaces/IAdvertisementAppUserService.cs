using AdvertisementProject.Common;
using AdvertisementProject.Common.Enums;
using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        /// <summary>
        /// kullanıcının açtiği ilanı ekler
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAdvertisementServiceAsync(AdvertisementAppUserCreateDto dto);

        /// <summary>
        /// ilanın durumuna göre ilanları liste şeklinde getirir
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<List<AdvertisementAppUserListDto>> GetListAdvertisementServiceAsync(AdvertisementAppUserStatusType type);


        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
