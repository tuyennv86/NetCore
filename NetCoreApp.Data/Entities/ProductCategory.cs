using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("ProductCategorys")]
    public class ProductCategory : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ISwitchable, ISortable
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, int? parentId, int? homeOrder, string image, bool? homeFlag, DateTime dateCreate,
            DateTime dateModified, string seoPageTile, string seoAlias, string seoKeyWords, string seoDescription, Status status, int sortOrder)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            DateCreated = dateCreate;
            DateModified = dateModified;
            SeoPageTitle = seoPageTile;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeyWords;
            SeoDescription = seoDescription;
            Status = status;
            SortOrder = sortOrder;

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }        
    }
}