using AdvertisementProject.Dtos.ProvidedServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.ProvidedServiceValidator
{
    public class ProvidedServiceCreateDtoValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Açıklama zorunludur");

            RuleFor(x => x.ImagePath)
                .NotEmpty()
                .WithMessage("Resim zorunludur");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıklama zorunludur");
        }
    }
}
