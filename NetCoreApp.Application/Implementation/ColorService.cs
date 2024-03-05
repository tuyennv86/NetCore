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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ColorViewModel Add(ColorViewModel colorVm)
        {
            var entity = _mapper.Map<ColorViewModel, Color>(colorVm);
            _colorRepository.Add(entity);
            return colorVm;
        }

        public void Delete(int id)
        {
            var entity = _colorRepository.FindById(id);
            _colorRepository.Remove(entity);
        }

        public void DeleteAll(int[] listId)
        {
            List<Color> list = new();
            foreach(int id in listId)
            {
                list.Add(_colorRepository.FindById(id));
            }
            _colorRepository.RemoveMultiple(list);
        }       

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ColorViewModel> GetAll()
        {
            return _mapper.ProjectTo<ColorViewModel>(_colorRepository.FindAll()).ToList();
        }

        public ColorViewModel GetById(int id)
        {
            return _mapper.Map<Color, ColorViewModel>(_colorRepository.FindById(id));
        }       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ColorViewModel colorVm)
        {
            var entity = _mapper.Map<ColorViewModel, Color>(colorVm);
            _colorRepository.Update(entity);            
        }
    }
}
