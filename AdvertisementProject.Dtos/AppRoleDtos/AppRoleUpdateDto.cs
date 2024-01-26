using AdvertisementProject.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Dtos.AppRoleDtos
{
    public class AppRoleUpdateDto:IUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Rol Adı")]
        [StringLength(50)]
        public string Definition { get; set; }
    }
}
