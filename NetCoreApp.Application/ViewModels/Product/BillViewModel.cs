using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.ViewModels.Product
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public string CustomerName { set; get; }              
        public string CustomerAddress { set; get; }
        public string CustomerMobile { set; get; }      
        public string CustomerMessage { set; get; }
        public PaymentMethod PaymentMethod { set; get; }
        public BillStatus BillStatus { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }       
        public Status Status { set; get; }
        public Guid CustomerId { set; get; }      
        public AppUser User { set; get; }
        public ICollection<BillDetail> BillDetails { set; get; }
    }
}
