using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class BillRepository: EFRepository<Bill, int>, IBillRepository
    {
        private readonly AppDbContext _context;
        public BillRepository(AppDbContext context) :base(context)
        {
            _context = context;
        }       
    }
}
