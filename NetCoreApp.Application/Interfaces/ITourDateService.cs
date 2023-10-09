using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface ITourDateService
    {
        TourDateViewModel Add(TourDateViewModel tourViewModel);
        void Update(TourDateViewModel tourViewModel);
        void Delete(int id);
        void DeleteAll(int[] listId);
        void DeleteByTourID(int TourID);
        List<TourDateViewModel> GetAll();
        List<TourDateViewModel> GetAll(string keyword);
        List<TourDateViewModel> GetAllByTourID(int TourID);
        PagedResult<TourDateViewModel> GetAllPaging(string keyword, int page, int pageSize);
        TourDateViewModel GetById(int id);      
        void UpdateStatus(int id);       
        void Save();
    }
}
