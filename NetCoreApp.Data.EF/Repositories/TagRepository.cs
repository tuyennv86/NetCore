using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        private readonly AppDbContext _context;
        public TagRepository(AppDbContext context) :base(context)
        {
            _context = context;
        }       
    }
}
