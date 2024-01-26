using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AdvertisementAppUserDtos
{
    public class AdvertisementAppUserCreateDto:IDto
    {
        [Display(Name ="İlan No")]
        public int AdvertisementId { get; set; }

        [Display(Name ="Kullanıcı")]
        public int AppUserId { get; set; }

        [Display(Name ="İlan Kullanıcı Durum No")]
        public int AdvertisementAppUserStatusId { get; set; }

        [Display(Name ="Askerlik Durumu No")]
        public int MilitaryStatusId { get; set; }

        [Display(Name ="Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }

        [Display(Name ="Deneyim Yılı")]
        public int WorkExperience { get; set; }

        [Display(Name ="Cv Resmi")]
        [StringLength(1000)]
        public string CvPath { get; set; }
    }
}
