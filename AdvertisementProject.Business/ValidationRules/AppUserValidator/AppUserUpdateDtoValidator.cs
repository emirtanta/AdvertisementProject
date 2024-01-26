using AdvertisementProject.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.AppUserValidator
{
    public class AppUserUpdateDtoValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage("Ad zorunludur");

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithMessage("Soyad zorunludur");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Kullanıcı adı zorunludur");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Telefon zorunludur");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre zorunludur");

            RuleFor(x => x.GenderId)
                .NotEmpty()
                .WithMessage("Cinsiyet zorunludur");
        }
    }
}
