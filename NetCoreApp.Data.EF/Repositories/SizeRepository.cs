using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class SizeRepository : EFRepository<Size, int>, ISizeRepository
    {
        private AppDbContext _context;

        public SizeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
