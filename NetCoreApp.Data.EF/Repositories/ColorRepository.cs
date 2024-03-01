using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class ColorRepository:EFRepository<Color, int>, IColorRepository
    {
        private AppDbContext _context;

    public ColorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
}
