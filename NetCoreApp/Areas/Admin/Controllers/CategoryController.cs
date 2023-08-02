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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string keyWord)
        {
            var _models = _categoryService.GetAll(keyWord);
            return new OkObjectResult(_models);
        }
        
        [HttpPost]
        public IActionResult GetById(int Id)
        {
            var _model = _categoryService.GetById(Id);
            return new OkObjectResult(_model);
        }

        [HttpPost]
        public IActionResult SaveEntity(CategoryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if (entity.Id == 0)
                {
                    _categoryService.Add(entity);
                }
                else
                {
                    _categoryService.Update(entity);
                }
                _categoryService.Save();
                return new OkObjectResult(entity);
            }
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _categoryService.Delete(Id);
                _categoryService.Save();
                return new OkObjectResult(Id);
            }
        }

        [HttpPost]
        public IActionResult DeleteByListID(int[] listId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _categoryService.DeleteAll(listId);
                _categoryService.Save();
                return new OkObjectResult(listId);
            }
        }
    }
}