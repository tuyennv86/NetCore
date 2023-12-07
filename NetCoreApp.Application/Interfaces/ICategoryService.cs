using NetCoreApp.Application.ViewModels.Category;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface ICategoryService: IDisposable
    {
        CategoryViewModel Add(CategoryViewModel categoryVm);

        void Update(CategoryViewModel categoryVm);

        void Delete(int id);
        
        void DeleteAll(int[] listId);

        List<CategoryViewModel> GetAll();

        List<CategoryViewModel> GetAll(string keyword);

        List<CategoryViewModel> GetByCategoryType(string keyWord, int categoryTypeID);

        List<CategoryViewModel> GetAllByParentId(int parentId, int categoryTypeID);

        CategoryViewModel GetById(int id);
        List<CategoryViewModel> GetByType(int type);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        List<CategoryViewModel> GetHomeCategories(int top);
        void UpdateOrder(int Id, int sortOrder, int homeOrder);
        void UpdateImageEmpty(int id);

        void UpdateHomeFalg(int id);

        void UpdateStatus(int id);

        void Save();
    }
}
