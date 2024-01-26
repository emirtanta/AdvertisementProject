using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Entities
{
    public class AppUser:BaseEntity
    {
        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
