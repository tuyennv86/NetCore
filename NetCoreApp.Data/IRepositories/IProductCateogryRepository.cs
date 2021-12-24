using NetCoreApp.Data.Entities;
using NetCoreApp.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace NetCoreApp.Data.IRepositories
{
    public interface IProductCateogryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}