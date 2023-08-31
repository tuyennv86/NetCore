using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class ImagesRepository : EFRepository<Images, int>, IImagesRepository
    {
        private AppDbContext _context;

        public ImagesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
