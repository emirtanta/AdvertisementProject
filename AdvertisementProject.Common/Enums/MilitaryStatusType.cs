using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Common.Enums
{
    public enum MilitaryStatusType
    {
        [Display(Name ="Yapıldı")]
        Yapildi=1,

        [Display(Name ="Tecilli")]
        Tecilli=2,

        [Display(Name ="Muaf")]
        Muaf=3,
    }
}
