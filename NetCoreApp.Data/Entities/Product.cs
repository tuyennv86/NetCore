using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ICreateTracking
    {
        public Product()
        {
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();
        }

        public Product(string name, int categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag, int order, int homeOrder,
            string tags, string unit, bool status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword, string seoMetaDescription)
        {
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Order = order;
            HomeOrder = homeOrder;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();
        }

        public Product(int id, string name, int categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag, int order, int homeOrder,
             string tags, string unit, bool status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword, string seoMetaDescription)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Order = order;
            HomeOrder = homeOrder;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            ProductImages = new List<ProductImage>();

        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { set; get; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public int Order { get; set; }
        public int HomeOrder { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }        
        public string SeoPageTitle { set; get; }

        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string SeoAlias { set; get; }

        [StringLength(255)]
        public string SeoKeywords { set; get; }

        [StringLength(255)]
        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public bool Status { set; get; }
        public Guid CreateById { get; set; }
        public Guid EditById { get; set; }
        
        [ForeignKey("CreateById")]
        public virtual AppUser CreateBy { set; get; }      
        [ForeignKey("EditById")]
        public virtual AppUser EditBy { set; get; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}