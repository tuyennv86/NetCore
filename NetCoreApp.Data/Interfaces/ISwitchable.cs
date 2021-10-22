using NetCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
