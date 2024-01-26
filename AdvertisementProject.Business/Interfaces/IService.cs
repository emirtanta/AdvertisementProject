using AdvertisementProject.Common;
using AdvertisementProject.Dtos.Interfaces;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IService<CreateDto,UpdateDto,ListDto,T> 
        where CreateDto : class,IDto,new()
        where UpdateDto : class,IUpdateDto,new()
        where ListDto:class,IDto,new()
        where T:BaseEntity
    {
        Task<IResponse<CreateDto>> CreateServiceAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateServiceAsync(UpdateDto dto);

        Task<IResponse<IDto>> GetByIdServiceAsync<IDto>(int id);

        Task<IResponse> RemoveServiceAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllServiceAsync();
    }
}
