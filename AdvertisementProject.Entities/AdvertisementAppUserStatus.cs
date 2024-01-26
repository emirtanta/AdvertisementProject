using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Entities
{
    public class AdvertisementAppUserStatus:BaseEntity
    {
        [StringLength(50)]
        public string Definition { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
