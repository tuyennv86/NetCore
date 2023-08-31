using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Data.Entities
{
    [Table("Images")]
    public class Images : DomainEntity<int>
    {
        public Images(string name, int tourId)
        {
            Name = name;
            TourId = tourId;
        }
        [StringLength(256)]
        [Required]
        public string Name { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
    }
}
