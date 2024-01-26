using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Common.Enums
{
    public enum GenderType
    {
        [Display(Name ="Erkek")]
        Erkek=1,

        [Display(Name ="Kadın")]
        Kadin=2
    }
}
