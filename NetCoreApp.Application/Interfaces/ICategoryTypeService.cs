﻿using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface ICategoryTypeService:IDisposable
    {
        CategoryTypeViewModel Add(CategoryTypeViewModel categoryTypeViewModel);

        void Update(CategoryTypeViewModel categoryTypeViewModel);

        void Delete(int id);

        List<CategoryTypeViewModel> GetAll();
        PagedResult<CategoryTypeViewModel> GetAllPaging(string keyword, int page, int pageSize);

        CategoryTypeViewModel GetById(int id);
        
        void UpdateOrder(int Id, int sortOrder);

        void UpdateIsDelete(int id, bool isDeleted);

        void Save();
    }
}
