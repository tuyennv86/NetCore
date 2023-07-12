using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Implementation
{
    public class CategoryTypeService:ICategoryTypeService
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryTypeService(ICategoryTypeRepository categoryTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryTypeRepository = categoryTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CategoryTypeViewModel Add(CategoryTypeViewModel categoryTypeViewModel)
        {
            var categoryType = _mapper.Map<CategoryTypeViewModel, CategoryType>(categoryTypeViewModel);
            _categoryTypeRepository.Add(categoryType);
            return categoryTypeViewModel;
        }

        public void Delete(int id)
        {
            _categoryTypeRepository.Remove(id);            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<CategoryTypeViewModel> GetAll()
        {
            return _mapper.ProjectTo<CategoryTypeViewModel>(_categoryTypeRepository.FindAll().OrderBy(x=> x.SortOrder)).ToList();
        }

        public PagedResult<CategoryTypeViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _categoryTypeRepository.FindAll();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
          
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<CategoryTypeViewModel>(query).ToList();

            var pageResult = new PagedResult<CategoryTypeViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return pageResult;
        }

        public CategoryTypeViewModel GetById(int id)
        {            
            return _mapper.Map<CategoryType, CategoryTypeViewModel>(_categoryTypeRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryTypeViewModel categoryTypeViewModel)
        {
            var categoryType = _mapper.Map<CategoryTypeViewModel, CategoryType>(categoryTypeViewModel);
            _categoryTypeRepository.Update(categoryType);
        }

        public void UpdateIsDelete(int id, bool isDeleted)
        {
            var categoryType = _categoryTypeRepository.FindById(id);
            categoryType.IsDeleted = isDeleted;
            _categoryTypeRepository.Update(categoryType);
        }

        public void UpdateOrder(int Id, int sortOrder)
        {
            var categoryType = _categoryTypeRepository.FindById(Id);
            categoryType.SortOrder = sortOrder;
            _categoryTypeRepository.Update(categoryType);
        }
    }
}
