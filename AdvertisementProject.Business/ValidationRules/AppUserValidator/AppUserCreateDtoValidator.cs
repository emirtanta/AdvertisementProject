using AdvertisementProject.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.AppUserValidator
{
    public class AppUserCreateDtoValidator:AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage("Ad alanı boş bırakılamaz");

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithMessage("Soyad alanı boş bırakılamaz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre alanı boş bırakılamaz");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Telefon boş olamaz");

            RuleFor(x => x.GenderId)
                .NotEmpty()
                .WithMessage("Cinsiyet boş olamaz");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş olamaz");
        }
    }
}
