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
    public class ProductQuantityService : IProductQuantityService
    {
        private readonly IProductQuantityRepository _productQuantityRepository;      
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductQuantityService(IProductQuantityRepository productQuantityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productQuantityRepository = productQuantityRepository;          
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
            _productQuantityRepository.Remove(Id);
        }

        public void DeleteByProductId(int ProductID)
        {
            var entities = _productQuantityRepository.FindAll(x => x.ProductId == ProductID).ToList();           
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
