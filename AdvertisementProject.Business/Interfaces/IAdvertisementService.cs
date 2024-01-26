using AdvertisementProject.Common;
using AdvertisementProject.Dtos.AdvertisementDtos;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        /// <summary>
        /// Aktif olan ilanları liste şeklinde getirir
        /// </summary>
        /// <returns></returns>
        Task<IResponse<List<AdvertisementListDto>>> GetActivesServiceAsync();
    }
}
