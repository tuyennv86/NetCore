using NetCoreApp.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface IFunctionService: IDisposable
    {
        void Add(FunctionViewModel functionVm);
        Task<List<FunctionViewModel>> GetAll(string filter);
        List<FunctionViewModel> GetAllByUser(string[] rolesIds);
        IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId);
        FunctionViewModel GetById(string id);

        void Update(FunctionViewModel functionVm);

        void Delete(string id);

        void Save();

        bool CheckExistedId(string id);

        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        void ReOrder(string sourceId, string targetId);
    }
}
