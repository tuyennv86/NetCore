﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ILogger _logger;

        public ProductCategoryController(IProductCategoryService productCategoryService, ILogger<ProductCategoryController> logger)
        {
            _productCategoryService = productCategoryService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetByParent(int parentId)
        {
            var model = _productCategoryService.GetAllByParentId(parentId);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult UpdateOrder(int Id, int homeOrder, int sortOrder)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }else
            {
                _productCategoryService.UpdateOrder(Id, homeOrder, sortOrder);
                _productCategoryService.Save();
                return new OkObjectResult(Id);
            }    
        }
        [HttpPost]
        public IActionResult UpdateHomeFalg(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _productCategoryService.UpdateHomeFalg(id);
                _productCategoryService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }else
            {
                _productCategoryService.UpdateStatus(id);
                _productCategoryService.Save();
                return new OkObjectResult(id);
            }    
        }

        [HttpPost]
        public IActionResult DeleteCategoryByID(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                _productCategoryService.Delete(id);
                _productCategoryService.Save();
                return new OkObjectResult(id);
            }
        }
        
        [HttpPost]
        public IActionResult GetByID(int id)
        {
            if(id <1)
            {
                return new BadRequestResult();
            }else
            {
                var category = _productCategoryService.GetById(id);
                return new OkObjectResult(category);
            }    
        }
    }
}
