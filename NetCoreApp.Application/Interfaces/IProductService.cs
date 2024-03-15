using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface IProductService:IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        ProductViewModel Add(ProductViewModel productVm, List<ProductImageViewModel> productImages);

        void Update(ProductViewModel productVm, List<ProductImageViewModel> productImages);

        void Delete(int id);
        public void DeleteAll(int[] listId);

        ProductViewModel GetById(int id);

        void ImportExcel(string filePath, int categoryId);

        void Save();

    }
}
