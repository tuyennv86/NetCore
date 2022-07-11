using AutoMapper;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
                c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<FunctionViewModel, Function>()
               .ConstructUsing(c => new Function(c.Name, c.URL, c.ParentId, c.IconCss, c.SortOrder));
        }
    }
}