﻿using NetCoreApp.Data.Enums;
using System;

namespace NetCoreApp.Application.ViewModels.Tour
{
    public class TourViewModel
    {
        public string Name { get; set; }       
        public string Preview { get; set; }        
        public int CategoryId { get; set; }
        public int Order { get; set; }
        public int HomeOrder { get; set; }
        public bool HomeStatus { get; set; }
        public decimal Price { get; set; }        
        public string TimeTour { get; set; }
        public DateTime DateStart { get; set; }        
        public string TransPort { get; set; }// vận chuyển        
        public string Service { get; set; }        
        public string Gift { get; set; } // quà tặng
        public string ServiceConten { get; set; }
        public string ServiceNotConten { get; set; }
        public string Cancellation { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public string CreateById { get; set; }
        public string EditById { get; set; }        
    }
}