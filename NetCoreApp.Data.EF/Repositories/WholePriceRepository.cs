using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class WholePriceRepository:EFRepository<WholePrice, int>, IWholePriceRepository
    {
        private AppDbContext _context;

        public WholePriceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
