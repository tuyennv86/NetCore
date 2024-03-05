using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface IProductTagService: IDisposable
    {
        ProductTagViewModel Add(ProductTagViewModel productTagViewModel);
        void Update(ProductTagViewModel productTagViewModel);
        void Delete(int id);
        void DeleteByProductId(int ProductId);
        void Save();
    }
}
