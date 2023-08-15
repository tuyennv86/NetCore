using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NetCoreApp.Application.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public CategoryViewModel Add(CategoryViewModel categoryVm)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(categoryVm);            
            _categoryRepository.Add(category);
            return categoryVm;
        }

        public void Delete(int id)
        {
            _categoryRepository.Remove(id);
        }

        public void DeleteAll(int[] listId)
        {
            List<Category> categories = new();
            foreach (int id in listId)
            {
                categories.Add(_categoryRepository.FindById(id));
            }
            _categoryRepository.RemoveMultiple(categories);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<CategoryViewModel> GetAll()
        {
            return _mapper.ProjectTo<CategoryViewModel>(_categoryRepository.FindAll().OrderBy(x => x.SortOrder)).ToList();
        }

        public List<CategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _mapper.ProjectTo<CategoryViewModel>(_categoryRepository.FindAll(x => x.Name.Contains(keyword)).OrderBy(x =>x.SortOrder)).ToList();
            }else
            {
                return _mapper.ProjectTo<CategoryViewModel>(_categoryRepository.FindAll().OrderBy(x => x.SortOrder)).ToList();
            }    
        }

        public List<CategoryViewModel> GetAllByParentId(int parentId, int categoryTypeID)
        {
            throw new NotImplementedException();
        }

        public List<CategoryViewModel> GetByCategoryType(string keyWord, int categoryTypeID)
        {
            var query = _categoryRepository.FindAll();
            if (!string.IsNullOrEmpty(keyWord))
                query = query.Where(x => x.Name.Contains(keyWord));
            if (categoryTypeID != 0)
                query = query.Where(x => x.CategoryTypeID == categoryTypeID);
            return _mapper.ProjectTo<CategoryViewModel>(query).ToList();
        }

        public CategoryViewModel GetById(int id)
        {
            return _mapper.Map<Category, CategoryViewModel>(_categoryRepository.FindById(id));
        }

        public List<CategoryViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
        }
       

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryViewModel categoryVm)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(categoryVm);
            _categoryRepository.Update(category);
        }

        public void UpdateHomeFalg(int id)
        {
            var category = _categoryRepository.FindById(id);
            category.HomeFlag = !category.HomeFlag;            
            _categoryRepository.Update(category);
        }

        public void UpdateOrder(int Id, int sortOrder, int homeOrder)
        {
            var category = _categoryRepository.FindById(Id);
            category.SortOrder = sortOrder;
            category.HomeOrder = homeOrder;
            _categoryRepository.Update(category);
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id)
        {
            var category = _categoryRepository.FindById(id);
            if (category.Status == Status.InActive)
                category.Status = Status.Active;
            else category.Status = Status.InActive;
            _categoryRepository.Update(category);
        }
    }
}
