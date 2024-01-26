using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Entities
{
    public class AdvertisementAppUser:BaseEntity
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatus AdvertisemenAppUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }

        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }

        [StringLength(1000)]
        public string CvPath { get; set; }
    }
}
