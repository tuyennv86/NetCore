using NetCoreApp.Application.ViewModels.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface IImagesService
    {
        ImagesViewModel Add(ImagesViewModel tourViewModel);
        void Update(ImagesViewModel tourViewModel);
        void Delete(int id);
        void DeleteAll(int[] listId);
        List<ImagesViewModel> GetAll(int TourID);
        ImagesViewModel GetById(int id);        
        void Save();
    }
}
