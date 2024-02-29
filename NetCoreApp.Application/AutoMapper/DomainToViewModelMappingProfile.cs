using AutoMapper;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Application.ViewModels.Tour;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CategoryType, CategoryTypeViewModel>();           
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Tour, TourViewModel>();
            CreateMap<TourDate, TourDateViewModel>();
            CreateMap<TourImages, TourImagesViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<AnnouncementUser, AnnouncementUserViewModel>();
            CreateMap<Announcement, AnnouncementViewModel>();
        }
    }
}