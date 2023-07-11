using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("CategoryTypes")]
    public class CategoryType : DomainEntity<int>, ISortable, IHasSoftDelete, IDateTracking
    {
        public CategoryType() { }
        public CategoryType(string name, int sortOrder, bool isDeleted, DateTime dateCreated, DateTime dateModified)
        {
            Name = name;
            SortOrder = sortOrder;
            IsDeleted = isDeleted;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }        
    }
}
