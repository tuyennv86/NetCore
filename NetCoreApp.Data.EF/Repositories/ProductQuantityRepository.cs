using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class ProductQuantityRepository : EFRepository<ProductQuantity, int>, IProductQuantityRepository
    {
        private AppDbContext _context;

        public ProductQuantityRepository(AppDbContext context) : base(context)
        {

        }
    }
}
