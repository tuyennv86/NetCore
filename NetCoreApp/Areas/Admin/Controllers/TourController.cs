using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        private readonly ITourService _tourService;        
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public TourController(ITourService tourService, ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _tourService = tourService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string name, int cateogryId, int pageIndex, int pageSize)
        {
            var models = _tourService.GetAllPaging(cateogryId, name, pageIndex, pageSize);
            return new OkObjectResult(models);
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            var model = _tourService.GetById(id);
            return new OkObjectResult(model);
        }
    }
}
