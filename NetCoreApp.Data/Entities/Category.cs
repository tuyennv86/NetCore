using Microsoft.AspNetCore.Http;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Categories")]
    public class Category : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking, ICreateTracking
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

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public int ParentId { get; set; }

        public int CategoryTypeID { get; set; }

        public int HomeOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }        
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        [StringLength(256)]
        public string SeoPageTitle { set; get; }
        [StringLength(256)]
        public string SeoAlias { set; get; }
        [StringLength(256)]
        public string SeoKeywords { set; get; }
        [StringLength(256)]
        public string SeoDescription { set; get; }
        public string Detail { get; set; }        
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        [StringLength(255)]
        public Guid CreateById { get; set; }
        [StringLength(255)]
        public Guid EditById { get; set; }
        [ForeignKey("Id")]
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Product> Products { set; get; }
        public virtual ICollection<Tour> Tours { set; get; }

    }
}