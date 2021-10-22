using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApp.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTile { get; set; }
        string SeoAlias { get; set; }
        string SeoKeyworks { get; set; }
        string SeoDescription { get; set; }
    }
}
