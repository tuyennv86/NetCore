using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class TourDateRepository : EFRepository<TourDate, int>, ITourDateRepository
    {
        private AppDbContext _context;

        public TourDateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
