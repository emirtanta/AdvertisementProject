using AdvertisementProject.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementProject.WebUI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        [Display(Name ="İlan")]
        public int AdvertisementId { get; set; }

        [Display(Name ="Kullanıcı")]
        public int AppUserId { get; set; }

        [Display(Name ="İlan Kullanıcı Durumu")]
        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Basvurdu;

        [Display(Name ="Askerlik Durumu")]
        public int MilitaryStatusId { get; set; }

        [Display(Name = "Tecil Tarihi")]
        public DateTime? EndDate { get; set; }

        [Display(Name ="İş Deneyiminiz")]
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }

    }
}
