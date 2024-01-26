using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementProject.WebUI.Models
{
    public class UserCreateModel
    {
        [Display(Name ="Ad")]
        [StringLength(100)]
        public string Firstname { get; set; }

        [Display(Name ="Soyad")]
        [StringLength(100)]
        public string Surname { get; set; }

        [Display(Name ="Kullanıcı Adı")]
        [StringLength(100)]
        public string Username { get; set; }

        [Display(Name ="Şifre")]
        [StringLength (100)]
        public string Password { get; set; }

        [Display(Name ="Şifre Tekrar")]
        [Compare("Password")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Telefon")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name ="Cinsiyet")]
        public int GenderId { get; set; }
        public SelectList  Genders { get; set; }
    }
}
