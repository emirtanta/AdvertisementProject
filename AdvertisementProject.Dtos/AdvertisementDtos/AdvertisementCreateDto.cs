﻿using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AdvertisementDtos
{
    public class AdvertisementCreateDto:IDto
    {

        [Display(Name = "İlan Başlığı")]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Durum")]
        public bool Status { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
