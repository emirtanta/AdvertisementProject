using AdvertisementProject.Dtos.GenderDtos;
using AdvertisementProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.Interfaces
{
    public interface IGenderService:IService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}
