using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class CategoryRepository : EFRepository<Category, int>, ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //public List<Category> GetByAlias(string alias)
        //{
        //    return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();
        //}
    }
}