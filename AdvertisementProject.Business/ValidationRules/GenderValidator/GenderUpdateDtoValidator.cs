using AdvertisementProject.Dtos.GenderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.ValidationRules.GenderValidator
{
    public class GenderUpdateDtoValidator:AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Definition)
                .NotEmpty()
                .WithMessage("Cinsiyet adı zorunludur");
        }
    }
}
