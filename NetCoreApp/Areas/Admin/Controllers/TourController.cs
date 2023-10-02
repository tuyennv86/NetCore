using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult GetAllPaging(string name, int cateogryId, int pageIndex, int pageSize)
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

        [HttpPost]
        public IActionResult SaveEntity(TourViewModel entity)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (entity.Id == 0)
                {
                    entity.CreateById = userId;
                    entity.EditById = userId;
                    entity.DateCreated = DateTime.Now;
                    entity.DateModified = DateTime.Now;
                    _tourService.Add(entity);
                }
                else
                {
                    entity.EditById = userId;
                    entity.DateModified = DateTime.Now;
                    _tourService.Update(entity);
                }
                _tourService.Save();
                return new OkResult();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _tourService.Delete(id);
                _tourService.Save();
                return new OkObjectResult(id);
            }
        }
        [HttpDelete]
        public IActionResult DeleteByListId(int[] listId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _tourService.DeleteAll(listId);
                _tourService.Save();
                return new OkObjectResult(listId);
            }
        }
    }
}
