using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Product;
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
    public class ProductQuantityService : IProductQuantityService
    {
        private readonly IProductQuantityRepository _productQuantityRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductQuantityService(IProductQuantityRepository productQuantityRepository,IColorRepository colorRepository, ISizeRepository sizeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productQuantityRepository = productQuantityRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }    
        public ProductQuantityViewModel Add(ProductQuantityViewModel productQuantityViewModel)
        {
            var entity = _mapper.Map<ProductQuantityViewModel, ProductQuantity>(productQuantityViewModel);
            _productQuantityRepository.Add(entity);
            return productQuantityViewModel;
        }

        public void Delete(int Id)
        {
            var entity = _productQuantityRepository.FindById(Id);
            //delete Color and Size            
            _colorRepository.Remove(entity.ColorId);
            _sizeRepository.Remove(entity.SizeId);
            _productQuantityRepository.Remove(Id);
        }

        public void DeleteByProductId(int ProductID)
        {
            var entities = _productQuantityRepository.FindAll(x => x.ProductId).ToList();
            List<Color> listColor = new();
            List<Size> listSize = new();
            foreach(ProductQuantity entiy in entities)
            {
                listColor.Add(_colorRepository.FindById(entiy.ColorId));
                listSize.Add(_sizeRepository.FindById(entiy.SizeId));
                
            }
            _colorRepository.RemoveMultiple(listColor);
            _sizeRepository.RemoveMultiple(listSize);
            _productQuantityRepository.RemoveMultiple(entities);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ProductQuantityViewModel GetById(int Id)
        {
            return _mapper.Map<ProductQuantity, ProductQuantityViewModel>(_productQuantityRepository.FindById(Id));
        }

        public List<ProductQuantityViewModel> GetByProductId(int ProductId)
        {
            return _mapper.ProjectTo<ProductQuantityViewModel>(_productQuantityRepository.FindAll(x => x.ProductId == ProductId)).ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductQuantityViewModel productQuantityViewModel)
        {
            var entity = _mapper.Map<ProductQuantityViewModel, ProductQuantity>(productQuantityViewModel);
            _productQuantityRepository.Update(entity);
        }
    }
}
