using AdvertisementProject.Dtos.AdvertisementAppUserStatusDtos;
using AdvertisementProject.Dtos.AdvertisementDtos;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.Dtos.MilitaryStatusDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AdvertisementAppUserDtos
{
    public class AdvertisementAppUserListDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="İlan No")]
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }

        [Display(Name ="Kullanıcı")]
        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }

        [Display(Name ="İlan Durum No")]
        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }

        [Display(Name ="Askerlik Durumu")]
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }

        [Display(Name ="Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }

        [Display(Name ="İş Deneyimi")]
        public int WorkExpericence { get; set; }

        [Display(Name ="Cv Resmi")]
        [StringLength(1000)]
        public string CvPath { get; set; }
    }
}
