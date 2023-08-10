using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Data.Interfaces
{
    public interface ICreateTracking
    {
        string CreateById { get; set; }
     
        string EditById { get; set; }
    }
}
