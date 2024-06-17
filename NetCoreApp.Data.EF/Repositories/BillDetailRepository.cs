using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;

namespace NetCoreApp.Data.EF.Repositories
{
    public class BillDetailRepository : EFRepository<BillDetail, int>, IBillDetailRepository
    {
        private readonly AppDbContext _context;
        public BillDetailRepository(AppDbContext context) :base(context)
        {
            _context = context;
        }       
    }
}
