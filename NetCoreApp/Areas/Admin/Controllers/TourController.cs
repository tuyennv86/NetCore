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

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        private readonly ITourService _tourService;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ITourDateService _tourDateService;
        private readonly IImagesService _imagesService;

        public TourController(ITourService tourService, ILogger<ProductController> logger,
            IWebHostEnvironment hostingEnvironment, ITourDateService tourDateService, IImagesService imagesService)
        {
            _tourService = tourService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _tourDateService = tourDateService;
            _imagesService = imagesService;
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
                //xóa lịch trình tour TourDate
                _tourDateService.DeleteByTourID(id);
                //xóa danh sách các ảnh liên quan Images
                var images = _imagesService.GetAll(id);
                foreach (ImagesViewModel image in images)
                {
                    if (!string.IsNullOrEmpty(image.Name))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + image.Name);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                }
                _imagesService.DeleteByTourId(id);
                //xóa ảnh đại diện và tour
                var model = _tourService.GetById(id);
                if (!string.IsNullOrEmpty(model.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + model.Image);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }
                _tourService.Delete(id);

                _tourDateService.Save();
                _imagesService.Save();
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
                foreach (int id in listId)
                {
                    var entity = _tourService.GetById(id);
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        //xóa lịch trình tour TourDate
                        _tourDateService.DeleteByTourID(id);
                        //xóa danh sách các ảnh liên quan Images
                        var images = _imagesService.GetAll(id);
                        foreach (ImagesViewModel image in images)
                        {
                            if (!string.IsNullOrEmpty(image.Name))
                            {
                                try
                                {
                                    System.IO.File.Delete(_hostingEnvironment.WebRootPath + image.Name);
                                }
                                catch (Exception ex) { _logger.LogError(ex.Message); }
                            }
                        }
                        _imagesService.DeleteByTourId(id);
                        //xóa ảnh đại diện dang sách tour
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                }
                _tourService.DeleteAll(listId);
                _tourDateService.Save();
                _imagesService.Save();
                _tourService.Save();
                return new OkObjectResult(listId);
            }
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _tourService.UpdateStatus(id);
                _tourService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult UpdateHomeStatus(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _tourService.UpdateHomeStatus(id);
                _tourService.Save();
                return new OkObjectResult(id);
            }
        }
    }
}