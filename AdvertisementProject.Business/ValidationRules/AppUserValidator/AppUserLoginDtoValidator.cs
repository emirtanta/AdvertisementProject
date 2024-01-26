using AdvertisementProject.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.AppUserValidator
{
    public class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x=>x.Username)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş olamaz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş olamaz");
        }
    }
}
