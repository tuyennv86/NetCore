using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Data.EF.Repositories
{
    public class CategoryTypeRepository: EFRepository<CategoryType, int>, ICategoryTypeRepository
    {
        private AppDbContext _context;

        public CategoryTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
