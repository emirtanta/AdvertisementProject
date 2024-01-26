using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Entities
{
    public class ProvidedService:BaseEntity
    {
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string? ImagePath { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
