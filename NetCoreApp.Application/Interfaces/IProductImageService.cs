using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface IProductImageService: IDisposable
    {
        ProductImageViewModel Add(ProductImageViewModel productImageViewModel);
        void Update(ProductImageViewModel productImageViewModel);
        void Delete(int id);
        void DeleteAll(int[] listId);
        void DeleteByProductId(int ProductID);
        List<ProductImageViewModel> GetAllByProductID(int ProductID);
        ProductImageViewModel GetById(int id);        
        void Save();
    }
}
