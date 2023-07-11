using AutoMapper;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CategoryType, CategoryTypeViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}