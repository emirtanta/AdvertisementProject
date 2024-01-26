﻿using AdvertisementProject.Dtos.GenderDtos;
using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AppUserDtos
{
    public class AppUserListDto:IDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Cinsiyet")]
        public int GenderId { get; set; }
        public GenderListDto Gender { get; set; }
    }
}
