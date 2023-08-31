using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Implementation
{
    public class TourDateService: ITourDateService
    {
        private readonly ITourDateRepository _tourDateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourDateService(ITourDateRepository tourDateRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tourDateRepository = tourDateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TourDateViewModel Add(TourDateViewModel tourViewModel)
        {
            var tour = _mapper.Map<TourDateViewModel, TourDate>(tourViewModel);
            _tourDateRepository.Add(tour);
            return tourViewModel;
        }

        public void Delete(int id)
        {
            _tourDateRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<TourDate> list = new();
            foreach(int id in listId)
            {
                list.Add(_tourDateRepository.FindById(id));
            }
            _tourDateRepository.RemoveMultiple(list);
        }

        public List<TourDateViewModel> GetAll()
        {
            return _mapper.ProjectTo<TourDateViewModel>(_tourDateRepository.FindAll()).ToList();
        }

        public List<TourDateViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _mapper.ProjectTo<TourDateViewModel>(_tourDateRepository.FindAll(x => x.Name.Contains(keyword))).ToList();
            }
            else
            {
                return _mapper.ProjectTo<TourDateViewModel>(_tourDateRepository.FindAll()).ToList();
            }
        }

        public PagedResult<TourDateViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _tourDateRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));           
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<TourDateViewModel>(query).ToList();

            var pageResult = new PagedResult<TourDateViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return pageResult;
        }

        public TourDateViewModel GetById(int id)
        {
            return _mapper.Map<TourDate, TourDateViewModel>(_tourDateRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TourDateViewModel tourViewModel)
        {
            var tour = _mapper.Map<TourDateViewModel, TourDate>(tourViewModel);
            _tourDateRepository.Update(tour);
        }

        public void UpdateStatus(int id)
        {
            var entity = _tourDateRepository.FindById(id);
            if (entity.Status == Status.Active)
                entity.Status = Status.InActive;
            else entity.Status = Status.Active;
            _tourDateRepository.Update(entity);
        }
    }
}
