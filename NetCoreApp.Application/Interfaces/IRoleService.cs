using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(AnnouncementViewModel announcementVm, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel roleVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(Guid id);


        Task UpdateAsync(AppRoleViewModel roleVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissionVm, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
        
    }
}
