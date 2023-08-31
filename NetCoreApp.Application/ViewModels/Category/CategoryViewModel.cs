using Microsoft.AspNetCore.Http;
using NetCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Application.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int ParentId { get; set; }
        public int CategoryTypeID { get; set; }
        public int HomeOrder { get; set; }
        public string Image { get; set; }
        public bool HomeFlag { get; set; }       
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
        public string Description { get; set; }
        public string Detail { get; set; }
        [NotMapped]
        public IFormFile filesImg { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string CreateById { get; set; }
        public string EditById { get; set; }        
        //public virtual CategoryViewModel Parent { get; set; }
        //public virtual ICollection<CategoryViewModel> Children { get; set; }
    }
}