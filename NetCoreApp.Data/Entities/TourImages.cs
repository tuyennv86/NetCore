using NetCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("TourImages")]
    public class TourImages : DomainEntity<int>
    {
        public TourImages()
        {
        }

        public TourImages(string name, int tourId)
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
