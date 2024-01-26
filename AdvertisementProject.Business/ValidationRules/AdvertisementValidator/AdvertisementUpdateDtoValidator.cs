using AdvertisementProject.Dtos.AdvertisementDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.AdvertisementValidator
{
    public class AdvertisementUpdateDtoValidator:AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlık boş bırakılamaz");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıklama boş bırakılamaz");
        }
    }
}
