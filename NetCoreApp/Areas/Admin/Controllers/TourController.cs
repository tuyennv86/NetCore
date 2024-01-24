using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Tour;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ICategoryTypeService _categoryTypeService;

        public TourController(ITourService tourService, ILogger<ProductController> logger, ICategoryTypeService categoryTypeService,
            IWebHostEnvironment hostingEnvironment, ITourDateService tourDateService, IImagesService imagesService)
        {
            _tourService = tourService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _tourDateService = tourDateService;
            _imagesService = imagesService;
            _categoryTypeService = categoryTypeService;
        }

        public IActionResult Index(int? id)
        {
            // ceck nếu có id thì lấy thông tin categoryType trả về view
            int typeId = (int)(id == null ? 0 : id);           
            var model = _categoryTypeService.GetById(typeId);
            if(model == null)
            {
                CategoryTypeViewModel model1 = new();
                return View(model1);
            }
            return View(model);
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
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // cập nhật ảnh
                if (entity.file != null)
                {
                    string pathPhoto = $@"\Uploaded\Images\{DateTime.Now:yyyyMMdd}";
                    string folder = _hostingEnvironment.WebRootPath + pathPhoto;
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string photoName = Path.GetFileName(entity.file.FileName);
                    string tempfileName = "";
                    string pathToCheck = Path.Combine(folder, photoName);

                    if (System.IO.File.Exists(pathToCheck))
                    {
                        int counter = 1;
                        while (System.IO.File.Exists(pathToCheck))
                        {
                            tempfileName = counter.ToString() + photoName;
                            pathToCheck = pathPhoto + tempfileName;
                            counter++;
                        }
                        photoName = tempfileName;
                    }

                    using FileStream stream = new(Path.Combine(folder, photoName), FileMode.Create);
                    entity.file.CopyTo(stream);
                    stream.Flush();
                    // xóa ảnh cũ nếu trước khi update ảnh đại diện               
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                    // đổi lại thành ảnh mới

                    entity.Image = Path.Combine(pathPhoto, photoName);
                }
                List<TourImagesViewModel> listTourImages = new();
                if (entity.files != null)
                {
                    // list ảnh
                    foreach (var file in entity.files)
                    {
                        string pathPhoto = $@"\Uploaded\Images\{DateTime.Now:yyyyMMdd}";
                        string folder = _hostingEnvironment.WebRootPath + pathPhoto;
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }

                        string photoName = Path.GetFileName(file.FileName);
                        string tempfileName = "";
                        string pathToCheck = Path.Combine(folder, photoName);

                        if (System.IO.File.Exists(pathToCheck))
                        {
                            int counter = 1;
                            while (System.IO.File.Exists(pathToCheck))
                            {
                                tempfileName = counter.ToString() + photoName;
                                pathToCheck = pathPhoto + tempfileName;
                                counter++;
                            }
                            photoName = tempfileName;
                        }

                        using FileStream stream = new(Path.Combine(folder, photoName), FileMode.Create);
                        file.CopyTo(stream);
                        stream.Flush();
                        TourImagesViewModel imagesView = new();

                        string ImagePath = Path.Combine(pathPhoto, photoName);
                        imagesView.Name = ImagePath;
                        imagesView.TourId = entity.Id;

                        listTourImages.Add(imagesView);                        
                    }
                }
                // hêt list ảnh 

                if (entity.Id == 0)
                {                    
                    entity.CreateById = new Guid(userId);
                    entity.EditById = new Guid(userId);
                    entity.DateModified = DateTime.Now;
                    _tourService.Add(entity, listTourImages);                    
                }
                else
                { 
                    entity.EditById = new Guid(userId);                    
                    entity.DateModified = DateTime.Now;
                    _tourService.Update(entity, listTourImages);
                }
                
                _tourService.Save();
                return new OkResult();
            }
        }

        [HttpDelete]
        public IActionResult DeleteImagesByImgId(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                var modelImg = _imagesService.GetById(id);
                if (!string.IsNullOrEmpty(modelImg.Name))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + modelImg.Name);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }
                _imagesService.Delete(id);
                _imagesService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpDelete]
        public IActionResult DeleteImge(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                var model = _tourService.GetById(id);                
                if (!string.IsNullOrEmpty(model.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + model.Image);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }               
                _tourService.UpdateImageEmpty(id);
                _tourService.Save();
                return new OkObjectResult(id);
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
                List<TourImagesViewModel> images = _imagesService.GetAll(id);
                foreach (TourImagesViewModel image in images)
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
                        foreach (TourImagesViewModel image in images)
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

        [HttpDelete]
        public IActionResult DeleteImageTour(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }else
            {
                _imagesService.Delete(id);
                _imagesService.Save();
                return new OkObjectResult(id);
            }    
        }
    }
}