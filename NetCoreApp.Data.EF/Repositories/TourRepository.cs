using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class TourRepository : EFRepository<Tour, int>, ITourRepository
    {
        private AppDbContext _context;

        public TourRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
