using AutoMapper;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
        }
    }
}