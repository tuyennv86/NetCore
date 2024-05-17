using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApp.Application.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SizeViewModel Add(SizeViewModel colorVm)
        {
            var entity = _mapper.Map<SizeViewModel, Size>(colorVm);
            _sizeRepository.Add(entity);
            return colorVm;
        }

        public void Delete(int id)
        {
            var entity = _sizeRepository.FindById(id);
            _sizeRepository.Remove(entity);
        }

        public void DeleteAll(int[] listId)
        {
            List<Size> list = new();
            foreach(int id in listId)
            {
                list.Add(_sizeRepository.FindById(id));
            }
            _sizeRepository.RemoveMultiple(list);
        }       

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<SizeViewModel> GetAll()
        {
            return _mapper.ProjectTo<SizeViewModel>(_sizeRepository.FindAll()).ToList();
        }

        public SizeViewModel GetById(int id)
        {
            return _mapper.Map<Size, SizeViewModel>(_sizeRepository.FindById(id));
        }       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SizeViewModel sizeVm)
        {
            var entity = _mapper.Map<SizeViewModel, Size>(sizeVm);
            _sizeRepository.Update(entity);            
        }
    }
}
