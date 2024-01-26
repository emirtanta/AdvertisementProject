using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Common.Enums
{
    public enum AdvertisementAppUserStatusType
    {
        [Display(Name ="Başvurdu")]
        Basvurdu=1,

        [Display(Name = "Mülakat")]
        Mulakat = 2,

        [Display(Name = "Olumsuz")]
        Olumsuz = 3,
    }
}
