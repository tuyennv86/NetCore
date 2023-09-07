using NetCoreApp.Data.Entities;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Data.IRepositories
{
    public interface IPermissionRepository: IRepository<Permission, int>
    {
    }
}
