using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class FunctionRepository: EFRepository<Function, string>,IFunctionRepository
    {
        private readonly AppDbContext _context;

        public FunctionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
