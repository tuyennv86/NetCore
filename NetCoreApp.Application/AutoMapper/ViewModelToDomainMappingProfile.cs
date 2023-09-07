using AutoMapper;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Data.Entities;
using System;

namespace NetCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryTypeViewModel, CategoryType>().ConstructUsing(c => new CategoryType(c.Name, c.SortOrder, c.IsDeleted, c.DateCreated, c.DateModified));

            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
                c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
            
            CreateMap<CategoryViewModel, Category>()
               .ConstructUsing(c => new Category(c.Name, c.Description, c.ParentId, c.CategoryTypeID, c.HomeOrder, c.Image, c.HomeFlag,
               c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.Detail));

            CreateMap<FunctionViewModel, Function>()
               .ConstructUsing(c => new Function(c.Name, c.URL, c.ParentId, c.IconCss, c.SortOrder));

            CreateMap<ProductViewModel, Product>()
               .ConstructUsing(c => new Product(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
               c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
               c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<TourViewModel, Tour>()
                .ConstructUsing(c => new Tour(c.Name, c.Preview, c.CategoryId, c.Order, c.HomeOrder, c.HomeStatus, c.Price, c.TimeTour,
               c.DateStart, c.TransPort, c.Service, c.Gift, c.ServiceConten, c.ServiceNotConten, c.Image, c.Status,
               c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
            
            CreateMap<ImagesViewModel, Images>().ConstructUsing(c => new Images(c.Name, c.TourId));

            CreateMap<TourDateViewModel, TourDate>().ConstructUsing(c => new TourDate(c.TourId, c.Name, c.Conten, c.Status));

            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName, c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
                .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));
        }
    }
}