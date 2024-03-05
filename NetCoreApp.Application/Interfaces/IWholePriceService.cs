using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface IWholePriceService:IDisposable
    {
        WholePriceViewMode Add(WholePriceViewMode wholePriceViewMode);
        void Update(WholePriceViewMode wholePriceViewMode);
        void Delete(int Id);
        void DeleteByProductId(int ProductID);
        WholePriceViewMode GetById(int Id);
        List<WholePriceViewMode> GetByProductID(int ProductID);
        void Save();
    }
}
