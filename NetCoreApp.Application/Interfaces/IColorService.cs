using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface IColorService: IDisposable
    {
        ColorViewModel Add(ColorViewModel colorVm);
        void Update(ColorViewModel colorVm);
        void Delete(int id);        
        void DeleteAll(int[] listId);        
        List<ColorViewModel> GetAll();        
        ColorViewModel GetById(int id);        
        void Save();
    }
}
