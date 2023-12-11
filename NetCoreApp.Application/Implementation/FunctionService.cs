﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Application.Implementation
{
    public partial class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;
       

        public FunctionService(IFunctionRepository functionRepository, IUnitOfWork unitOfWork, IMapper mapper, IPermissionRepository permissionRepository)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public void Add(FunctionViewModel functionVm)
        {
            _functionRepository.Add(_mapper.Map<Function>(functionVm));
        }

        public bool CheckExistedId(string id)
        {
            return _functionRepository.FindById(id) != null;
        }

        public void Delete(string id)
        {
            _functionRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var query = _functionRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            return _mapper.ProjectTo<FunctionViewModel>(query.OrderBy(x => x.SortOrder)).ToListAsync();
        }

        public List<FunctionViewModel> GetAllByUser(string[] rolesIds)
        {            
            var functions = _functionRepository.FindAll();
            var permissions = _permissionRepository.FindAll();

            var query = (from f in functions
                        join p in permissions on f.Id equals p.FunctionId
                        where rolesIds.Contains(p.RoleId.ToString()) && (p.CanCreate || p.CanUpdate || p.CanDelete || p.CanRead) && f.Status == Status.Active
                        select f).Distinct();            
            return _mapper.ProjectTo<FunctionViewModel>(query.OrderBy(x => x.SortOrder)).ToList();
        }

        public IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId)
        {
            return _mapper.ProjectTo<FunctionViewModel>(_functionRepository.FindAll(x => x.ParentId == parentId && x.Status == Status.Active).OrderBy(x => x.SortOrder));
        }

        public FunctionViewModel GetById(string id)
        {
            return _mapper.Map<Function, FunctionViewModel>(_functionRepository.FindById(id));
        }

        public void ReOrder(string sourceId, string targetId)
        {
            var source = _functionRepository.FindById(sourceId);
            var target = _functionRepository.FindById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _functionRepository.Update(source);
            _functionRepository.Update(target);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FunctionViewModel functionVm)
        {
            var functionEntiy = _mapper.Map<FunctionViewModel, Function>(functionVm);
            _functionRepository.Update(functionEntiy);
        }

        public void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            var funtionEntiy = _functionRepository.FindById(sourceId);
            funtionEntiy.ParentId = targetId;
            _functionRepository.Update(funtionEntiy);
            //Get all sibling
            var sibling = _functionRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _functionRepository.Update(child);
            }
        }
    }
}