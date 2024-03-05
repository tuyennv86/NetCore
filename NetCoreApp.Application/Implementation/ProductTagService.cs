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
    public class ProductTagService : IProductTagService
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork, IMapper mapper, ITagRepository tagRepository)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }
        public ProductTagViewModel Add(ProductTagViewModel productTagViewModel)
        {
            var entity = _mapper.Map<ProductTagViewModel, ProductTag>(productTagViewModel);
            _productTagRepository.Add(entity);
            return productTagViewModel;
        }

        public void Delete(int id)
        {
            _productTagRepository.Remove(id);
        }

        public void DeleteByProductId(int ProductId)
        {
            var entities = _productTagRepository.FindAll(x => x.ProductId == ProductId).ToList();
            List<Tag> tags = new();
            foreach(ProductTag productTag in entities)
            {
                tags.Add(_tagRepository.FindById(productTag.TagId));
            }
            _tagRepository.RemoveMultiple(tags);
            _productTagRepository.RemoveMultiple(entities);
        }

        public void Update(ProductTagViewModel productTagViewModel)
        {
            var entity = _mapper.Map<ProductTagViewModel, ProductTag>(productTagViewModel);
            _productTagRepository.Update(entity);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
