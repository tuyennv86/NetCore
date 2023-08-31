using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Implementation
{
    public class ImagesService : IImagesService
    {
        private readonly IImagesRepository _imagesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImagesService(IImagesRepository imagesRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _imagesRepository = imagesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ImagesViewModel Add(ImagesViewModel imagesViewModel)
        {
            var entity = _mapper.Map<ImagesViewModel, Images>(imagesViewModel);
            _imagesRepository.Add(entity);
            return imagesViewModel;
        }

        public void Delete(int id)
        {
            _imagesRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<Images> list = new();
            foreach(int id in listId)
            {
                list.Add(_imagesRepository.FindById(id));
            }
            _imagesRepository.RemoveMultiple(list);
        }

        public List<ImagesViewModel> GetAll(int TourID)
        {
            return _mapper.ProjectTo<ImagesViewModel>(_imagesRepository.FindAll(x => x.TourId == TourID)).ToList();
        }

        public ImagesViewModel GetById(int id)
        {
            return _mapper.Map<Images, ImagesViewModel>(_imagesRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImagesViewModel imagesViewModel)
        {
            var entity = _mapper.Map<ImagesViewModel, Images>(imagesViewModel);
            _imagesRepository.Update(entity);
        }
        
    }
}
