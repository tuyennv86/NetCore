using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Brands")]
    public class Brand : DomainEntity<int>, ISwitchable
    {
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        public Status Status { get; set; }
    }
}