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
        TourImagesViewModel Add(TourImagesViewModel imagesViewModel);
        void Update(TourImagesViewModel imagesViewModel);
        void Delete(int id);
        void DeleteAll(int[] listId);
        void DeleteByTourId(int TourID);
        List<TourImagesViewModel> GetAll(int TourID);
        TourImagesViewModel GetById(int id);        
        void Save();
    }
}
