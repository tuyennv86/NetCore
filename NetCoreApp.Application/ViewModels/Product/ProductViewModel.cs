using Microsoft.AspNetCore.Http;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }// giá khuyến mại
        [Required]
        public decimal OriginalPrice { get; set; }// giá gốc
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
        public CategoryViewModel Category { set; get; }
        public string SeoPageTitle { set; get; }
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
        public AppUserViewModel CreateBy { set; get; }        
        public AppUserViewModel EditBy { set; get; }
        public ICollection<ProductTagViewModel> ProductTags { set; get; }
        public ICollection<ProductImageViewModel> ProductImages { get; set; }
        public ICollection<ProductQuantityViewModel> ProductQuantities { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        [NotMapped]
        public List<IFormFile> files { get; set; }
    }
}