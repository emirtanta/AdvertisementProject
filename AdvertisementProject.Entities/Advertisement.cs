using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Entities
{
    public class Advertisement:BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }

        public bool Status { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
