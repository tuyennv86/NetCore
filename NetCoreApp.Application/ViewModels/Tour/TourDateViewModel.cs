using NetCoreApp.Data.Enums;
using System;

namespace NetCoreApp.Application.ViewModels.Tour
{
    public class TourDateViewModel
    {
        public int TourId { get; set; }                
        public string Name { get; set; }
        public string Conten { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreateById { get; set; }
        public string EditById { get; set; }
    }
}
