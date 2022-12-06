using Microsoft.AspNetCore.Mvc;
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
    }
}
