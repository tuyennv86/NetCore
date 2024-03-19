using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Utilities.Constants;
using NetCoreApp.Utilities.Dtos;
using NetCoreApp.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApp.Application.Implementation
{
    public class ProductService:IProductService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper, 
            ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
        }

        public ProductViewModel Add(ProductViewModel productVm, List<ProductImageViewModel> productImagesVm)
        {
            List<ProductTag> productTags = new();
            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new()
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new()
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }

                var product = _mapper.Map<ProductViewModel, Product>(productVm);
                foreach (var productTag in productTags)
                {
                    product.ProductTags.Add(productTag);
                }
                
                foreach(ProductImageViewModel productImageVm in productImagesVm)
                {
                    var productImage = _mapper.Map<ProductImageViewModel, ProductImage>(productImageVm);
                    product.ProductImages.Add(productImage);
                }
                _productRepository.Add(product);
            }
            return productVm;
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }
        public void DeleteAll(int[] listId)
        {
            List<Product> products = new();
            foreach (int id in listId)
            {
                products.Add(_productRepository.FindById(id));
            }
            _productRepository.RemoveMultiple(products);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll()).ToList();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue && categoryId != 0)
                query = query.Where(x => x.CategoryId == categoryId.Value);
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();            

            var pageResult = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return pageResult;
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

        public void ImportExcel(string filePath, int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductViewModel productVm, List<ProductImageViewModel> productImages)
        {
            List<ProductTag> productTags = new();

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productVm.Id).ToList());
                    ProductTag productTag = new()
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
            }

            var product = _mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            foreach (ProductImageViewModel productImage in productImages)
            {
                product.ProductImages.Add(_mapper.Map<ProductImageViewModel, ProductImage>(productImage));
            }
            _productRepository.Update(product);
        }
    }
}
