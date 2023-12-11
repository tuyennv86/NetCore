using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Data.Interfaces
{
    public interface ICreateTracking
    {
        Guid CreateById { get; set; }
     
        Guid EditById { get; set; }
    }
}
