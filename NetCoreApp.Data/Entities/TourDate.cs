using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("TourDates")]
    public class TourDate : DomainEntity<int>, ISwitchable, IDateTracking, ICreateTracking
    {
        public TourDate(int tourId, string name, string conten, Status status)
        {
            TourId = tourId;
            Name = name;
            Conten = conten;
            Status = status;
        }

        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public string Conten { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Guid CreateById { get; set ; }
        public Guid EditById { get; set; }
    }
}
