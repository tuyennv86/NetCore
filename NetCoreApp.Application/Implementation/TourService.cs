﻿using AutoMapper;
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

namespace NetCoreApp.Application.Implementation
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public TourViewModel Add(TourViewModel tourViewModel)
        {
            var tour = _mapper.Map<TourViewModel, Tour>(tourViewModel);
            _tourRepository.Add(tour);
            return tourViewModel;
        }

        public void Delete(int id)
        {
            _tourRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<Tour> tours = new();
            foreach(int id in listId)
            {
                tours.Add(_tourRepository.FindById(id));
            }
            _tourRepository.RemoveMultiple(tours);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<TourViewModel> GetAll()
        {
            return _mapper.ProjectTo<TourViewModel>(_tourRepository.FindAll().OrderBy(x => x.Order)).ToList();
        }

        public List<TourViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _mapper.ProjectTo<TourViewModel>(_tourRepository.FindAll(x => x.Name.Contains(keyword)).OrderBy(x => x.Order)).ToList();
            }else
            {
                return _mapper.ProjectTo<TourViewModel>(_tourRepository.FindAll().OrderBy(x => x.Order)).ToList();
            }    
        }

        public PagedResult<TourViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _tourRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<TourViewModel>(query).ToList();

            var pageResult = new PagedResult<TourViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return pageResult;
        }

        public TourViewModel GetById(int id)
        {
            return _mapper.Map<Tour, TourViewModel>(_tourRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TourViewModel tourViewModel)
        {
            var tour = _mapper.Map<TourViewModel, Tour>(tourViewModel);
            _tourRepository.Update(tour);
        }

        public void UpdateHomeStatus(int id)
        {
            var entity = _tourRepository.FindById(id);
            entity.HomeStatus = !entity.HomeStatus;
            _tourRepository.Update(entity);
        }

        public void UpdateImageEmpty(int id)
        {
            var entity = _tourRepository.FindById(id);
            entity.Image = "";
            _tourRepository.Update(entity);
        }

        public void UpdateOrder(int Id, int sortOrder, int homeOrder)
        {
            var entity = _tourRepository.FindById(Id);
            entity.Order = sortOrder;
            entity.HomeOrder = homeOrder;
            _tourRepository.Update(entity);
        }

        public void UpdateStatus(int id)
        {
            var entity = _tourRepository.FindById(id);
            if (entity.Status == Status.InActive)
                entity.Status = Status.Active;
            else entity.Status = Status.InActive;
            _tourRepository.Update(entity);
        }
    }
}
