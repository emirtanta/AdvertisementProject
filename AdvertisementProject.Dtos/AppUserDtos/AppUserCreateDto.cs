using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AppUserDtos
{
    public class AppUserCreateDto:IDto
    {

        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string Username { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Cinsiyet")]
        public int GenderId { get; set; }
    }
}
