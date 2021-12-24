using AutoMapper;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(c => new ProductCategory(
                c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag, c.DateCreated, c.DateModified,
                c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.Status, c.SortOrder));
        }
    }
}