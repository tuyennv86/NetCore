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
    public class TourController : Controller
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
    }
}
