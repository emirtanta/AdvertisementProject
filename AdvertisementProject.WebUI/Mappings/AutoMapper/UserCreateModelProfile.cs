using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.WebUI.Models;
using AutoMapper;

namespace AdvertisementProject.WebUI.Mappings.AutoMapper
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
