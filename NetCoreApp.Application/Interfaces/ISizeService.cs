using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface ISizeService: IDisposable
    {
        SizeViewModel Add(SizeViewModel colorVm);
        void Update(SizeViewModel colorVm);
        void Delete(int id);        
        void DeleteAll(int[] listId);        
        List<SizeViewModel> GetAll();        
        SizeViewModel GetById(int id);        
        void Save();
    }
}
