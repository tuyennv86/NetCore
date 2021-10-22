using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApp.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDelete { get; set; }
    }
}
