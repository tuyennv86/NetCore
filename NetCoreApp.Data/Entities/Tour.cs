using NetCoreApp.Data.Enums;
using NetCoreApp.Data.Interfaces;
using NetCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreApp.Data.Entities
{
    [Table("Tours")]
    public class Tour : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData, ICreateTracking
    {
        public Tour()
        {
            TourImages = new List<TourImages>();
            TourDates = new List<TourDate>();
        }
        public Tour(string name, string preview, int categoryId, int order, int homeOrder, bool homeStatus, decimal price, string timeTour, string dateStart, 
            string transPort, string service, string gift, string serviceConten, string serviceNotConten, string image, 
            Status status, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription)
        {
            Name = name;
            Preview = preview;
            CategoryId = categoryId;
            Order = order;
            HomeOrder = homeOrder;
            HomeStatus = homeStatus;
            Price = price;
            TimeTour = timeTour;
            DateStart = dateStart;
            TransPort = transPort;
            Service = service;
            Gift = gift;
            ServiceConten = serviceConten;
            ServiceNotConten = serviceNotConten;
            Image = image;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            TourImages = new List<TourImages>();
            TourDates = new List<TourDate>();
        }

        [StringLength(256)]
        [Required]
        public string Name { get; set; }
        [StringLength(512)]
        public string Preview { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { set; get; }

        public int Order { get; set; }
        public int HomeOrder { get; set; }
        public bool HomeStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [StringLength(256)]
        public string TimeTour { get; set; }
        public string DateStart { get; set; }
        [StringLength(256)]        
        public string TransPort { get; set; }// vận chuyển
        [StringLength(256)]
        public string Service { get; set; }
        [StringLength(256)]
        public string Gift { get; set; } // quà tặng
        public string ServiceConten { get; set; }
        public string ServiceNotConten { get; set; }        
        public string Image { get; set; }        
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string SeoPageTitle { get ; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set ; }
        public string CreateById { get; set; }
        public string EditById { get; set; }
        public virtual ICollection<TourDate> TourDates { set; get; }// lịch trình tour
        public virtual ICollection<TourImages> TourImages { get; set; }        
    }
}
