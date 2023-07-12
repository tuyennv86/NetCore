﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class CategoryTypeController : BaseController
    {
        private readonly ICategoryTypeService _categoryTypeService;
        private readonly ILogger _logger;

        public CategoryTypeController(ICategoryTypeService categoryTypeService, ILogger<CategoryTypeController> logger)
        {
            _categoryTypeService = categoryTypeService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _categoryTypeService.GetAll();
            return new OkObjectResult(models);
        }

        [HttpGet]
        public IActionResult GetByPageding(string keyWord, int pageIndex, int pageSize)
        {
            var models = _categoryTypeService.GetAllPaging(keyWord, pageIndex, pageSize);
            return new OkObjectResult(models);
        }
        [HttpPost]
        public IActionResult GetById(int Id)
        {
            var model = _categoryTypeService.GetById(Id);
            return new OkObjectResult(model);
        }
        [HttpPost]
        public IActionResult SaveEntity(CategoryTypeViewModel categoryTypeViewmodel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {                
                if(categoryTypeViewmodel.Id == 0)
                {
                    _categoryTypeService.Add(categoryTypeViewmodel);
                }else
                {
                    _categoryTypeService.Update(categoryTypeViewmodel);
                }
                _categoryTypeService.Save();
                return new OkObjectResult(categoryTypeViewmodel);
            }    
            
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }else
            {
                _categoryTypeService.Delete(Id);
                _categoryTypeService.Save();
                return new OkObjectResult(Id);
            }    
        }
        [HttpPost]
        public IActionResult DeleteByListID(string listId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                foreach(string i in listId.Split(listId,';'))
                {
                    _categoryTypeService.Delete(int.Parse(i));
                    _categoryTypeService.Save();
                }    
               
                return new OkObjectResult(listId);
            }
        }
    }
}