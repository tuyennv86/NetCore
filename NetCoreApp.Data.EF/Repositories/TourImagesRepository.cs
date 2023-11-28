using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class TourImagesRepository : EFRepository<TourImages, int>, ITourImagesRepository
    {
        private AppDbContext _context;

        public TourImagesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
