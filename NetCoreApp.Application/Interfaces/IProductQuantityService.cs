using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface IProductQuantityService: IDisposable
    {
        ProductQuantityViewModel Add(ProductQuantityViewModel productQuantityViewModel);
        void Update(ProductQuantityViewModel productQuantityViewModel);
        void Delete(int Id);
        void DeleteByProductId(int ProductID);
        void Save();
        ProductQuantityViewModel GetById(int Id);        
        List<ProductQuantityViewModel> GetByProductId(int ProductId);
    }
}
