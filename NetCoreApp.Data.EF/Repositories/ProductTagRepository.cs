using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag, int>, IProductTagRepository
    {
        private readonly AppDbContext _context;
        public ProductTagRepository(AppDbContext context) :base(context)
        {
            _context = context;
        }       
    }
}
