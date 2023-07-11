using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Categories")]
    public class Category : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {        
        public Category()
        {

        }
        public Category(string name, string description, int parentId, int categoryTypeId, int homeOrder,
            string image, bool homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeywords, string seoDescription, string detail)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            CategoryTypeID = categoryTypeId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            Detail = detail;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public int CategoryTypeID { get; set; }

        public int HomeOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }

        public string Detail { get; set; }

        [ForeignKey("Id")]
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
    }
}