using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AppUserDtos
{
    public class AppUserLoginDto:IDto
    {
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
