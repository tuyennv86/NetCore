using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApp.Application.Implementation
{
    public class TourImagesService : ITourImagesService
    {
        private readonly ITourImagesRepository _imagesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourImagesService(ITourImagesRepository imagesRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _imagesRepository = imagesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public TourImagesViewModel Add(TourImagesViewModel imagesViewModel)
        {
            var entity = _mapper.Map<TourImagesViewModel, TourImages>(imagesViewModel);
            _imagesRepository.Add(entity);
            return imagesViewModel;
        }

        public void Delete(int id)
        {
            _imagesRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<TourImages> list = new();
            foreach(int id in listId)
            {
                list.Add(_imagesRepository.FindById(id));
            }
            _imagesRepository.RemoveMultiple(list);
        }

        public void DeleteByTourId(int TourID)
        {
            var entities = _imagesRepository.FindAll(x => x.TourId == TourID).ToList();
            _imagesRepository.RemoveMultiple(entities);

        }

        public List<TourImagesViewModel> GetAll(int TourID)
        {
            return _mapper.ProjectTo<TourImagesViewModel>(_imagesRepository.FindAll(x => x.TourId == TourID)).ToList();
        }

        public TourImagesViewModel GetById(int id)
        {
            return _mapper.Map<TourImages, TourImagesViewModel>(_imagesRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Update(TourImagesViewModel imagesViewModel)
        {
            var entity = _mapper.Map<TourImagesViewModel, TourImages>(imagesViewModel);
            _imagesRepository.Update(entity);
        }
        
    }
}
