using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AdvertisementAppUserStatusDtos
{
    public class AdvertisementAppUserStatusListDto
    {
        [Display(Name ="Tanım")]
        [StringLength(50)]
        public string Definition { get; set; }
    }
}
