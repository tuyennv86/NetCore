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
    public class ProductImageService:IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductImageService(IProductImageRepository productImageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductImageViewModel Add(ProductImageViewModel productImageViewModel)
        {
            var entity = _mapper.Map<ProductImageViewModel, ProductImage>(productImageViewModel);
            _productImageRepository.Add(entity);
            return productImageViewModel;
        }

        public void Delete(int id)
        {
            _productImageRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<ProductImage> list = new();
            foreach(int id in listId)
            {
                list.Add(_productImageRepository.FindById(id));
            }
            _productImageRepository.RemoveMultiple(list);
        }

        public void DeleteByProductId(int ProductID)
        {
            var list = _productImageRepository.FindAll(x => x.ProductId == ProductID).ToList();
            _productImageRepository.RemoveMultiple(list);
        }

        public List<ProductImageViewModel> GetAll(int ProductID)
        {            
            return _mapper.ProjectTo<ProductImageViewModel>(_productImageRepository.FindAll(x => x.ProductId == ProductID)).ToList();
        }

        public ProductImageViewModel GetById(int id)
        {
            var entity = _productImageRepository.FindById(id);
            return _mapper.Map<ProductImage, ProductImageViewModel>(entity);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductImageViewModel productImageViewModel)
        {
            var entity = _mapper.Map<ProductImageViewModel, ProductImage>(productImageViewModel);
            _productImageRepository.Update(entity);
        }
    }
}
