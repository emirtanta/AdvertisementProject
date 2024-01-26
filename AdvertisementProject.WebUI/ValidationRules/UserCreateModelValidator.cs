using AdvertisementProject.WebUI.Models;
using FluentValidation;

namespace AdvertisementProject.WebUI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password)
                .MinimumLength(3)
                .WithMessage("Parola en az 3 karakter olmalıdır");
            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Parolalar eşleşmiyor");

            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage("Ad boş olamaz");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Soyad boş olamaz");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Username)
                .MinimumLength(3)
                .WithMessage("Kullanıcı adı en az 3 karakter olmalıdır");

            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname))
            .WithMessage("Kullanıcı adı adınızı içeremez")
            .When(x => x.Username != null && x.Firstname != null);

            RuleFor(x => x.GenderId)
                .NotEmpty()
                .WithMessage("Cinsiyet seçimi zorunludur");
        }

        /// <summary>
        /// adın kullanıcı adı ile aynı olmama durumunu kontrol eder
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firtname"></param>
        /// <returns></returns>
        private bool CanNotFirstname(string username,string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
