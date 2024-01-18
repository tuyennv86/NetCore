using Microsoft.AspNetCore.Http;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.EF;
using NetCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Application.ViewModels.Tour
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Preview { get; set; }        
        public int CategoryId { get; set; }
        public CategoryViewModel Category { set; get; }
        public int Order { get; set; }
        public int HomeOrder { get; set; }
        public bool HomeStatus { get; set; }
        public decimal Price { get; set; }        
        public string TimeTour { get; set; }
        public string DateStart { get; set; }        
        public string TransPort { get; set; }// vận chuyển        
        public string Service { get; set; }        
        public string Gift { get; set; } // quà tặng
        public string ServiceConten { get; set; }
        public string ServiceNotConten { get; set; }        
        public string Image { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Guid CreateById { get; set; }
        public AppUserViewModel CreateBy { set; get; }
        public Guid EditById { get; set; }        
        public AppUserViewModel EditBy { set; get; }
        public ICollection<TourDateViewModel> TourDates { set; get; }// lịch trình tour
        public ICollection<TourImagesViewModel> TourImages { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }
        [NotMapped]
        public List<IFormFile> files { get; set; }
    }
}
