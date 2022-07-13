using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreApp.Data.EF.Repositories
{
    public class ProductRepository: EFRepository<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) :base(context)
        {
            _context = context;
        }       
    }
}
