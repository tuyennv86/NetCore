using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
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
    }
}
