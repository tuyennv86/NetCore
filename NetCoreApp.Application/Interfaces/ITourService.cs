using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Interfaces
{
    public interface ITourService:IDisposable
    {
        TourViewModel Add(TourViewModel tourViewModel, List<TourImagesViewModel> tourImages);
        void Update(TourViewModel tourViewModel, List<TourImagesViewModel> tourImages);
        void Delete(int id);
        void DeleteAll(int[] listId);
        List<TourViewModel> GetAll();
        List<TourViewModel> GetAll(string keyword);
        PagedResult<TourViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
        TourViewModel GetById(int id);        
        void UpdateOrder(int Id, int sortOrder, int homeOrder);
        void UpdateImageEmpty(int id);
        void UpdateStatus(int id);
        void UpdateHomeStatus(int id);
        void Save();
    }
}
