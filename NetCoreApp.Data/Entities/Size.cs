using NetCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Sizes")]
    public class Size : DomainEntity<int>
    {
        [StringLength(250)]
        public string Name
        {
            get; set;
        }
    }
}