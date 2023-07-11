using NetCoreApp.Data.Entities;
using NetCoreApp.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace NetCoreApp.Data.IRepositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        //List<ProductCategory> GetByAlias(string alias);
    }
}