using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _categoryService = categoryService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _categoryService.GetAll();
            return new OkObjectResult(models);
        }

        [HttpPost]
        public IActionResult GetByTypeAndKeyWord(string keyWord, int categoryTypeID)
        {
            var _models = _categoryService.GetByCategoryType(keyWord, categoryTypeID);
            return new OkObjectResult(_models);
        }

        [HttpPost]
        public IActionResult GetById(int Id)
        {            
            var model = _categoryService.GetById(Id);
            return new OkObjectResult(model);
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
                if (entity.filesImg != null)
                {
                    string pathPhoto = $@"\Uploaded\Images\{DateTime.Now:yyyyMMdd}";
                    string folder = _hostingEnvironment.WebRootPath + pathPhoto;
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string photoName = Path.GetFileName(entity.filesImg.FileName);
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
                    entity.filesImg.CopyTo(stream);
                    stream.Flush();
                    entity.Image = Path.Combine(pathPhoto, photoName);
                }

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (entity.Id == 0)
                {
                    entity.CreateById = userId;
                    entity.EditById = userId;
                    entity.DateCreated = DateTime.Now;
                    entity.DateModified = DateTime.Now;
                    _categoryService.Add(entity);
                }
                else
                {
                    entity.EditById = userId;
                    entity.DateModified = DateTime.Now;
                    _categoryService.Update(entity);
                }
                _categoryService.Save();
                return new OkResult();
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
                var entity = _categoryService.GetById(Id);
                if (!string.IsNullOrEmpty(entity.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                        
                }
                _categoryService.Delete(Id);
                _categoryService.Save();
                return new OkObjectResult(Id);
            }
        }

        [HttpPost]
        public IActionResult DeleteImage(int Id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                var model = _categoryService.GetById(Id);
                if (!string.IsNullOrEmpty( model.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + model.Image);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }
                _categoryService.UpdateImageEmpty(Id);
                _categoryService.Save();
                return new OkObjectResult(model);
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
                foreach(int id in listId)
                {
                    var entity = _categoryService.GetById(id);
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                }
                _categoryService.DeleteAll(listId);
                _categoryService.Save();
                return new OkObjectResult(listId);
            }
        }

        [HttpPost]
        public IActionResult UpdateOrder(int Id, int homeOrder, int sortOrder)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _categoryService.UpdateOrder(Id, homeOrder, sortOrder);
                _categoryService.Save();
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
                _categoryService.UpdateHomeFalg(id);
                _categoryService.Save();
                return new OkObjectResult(id);
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
                _categoryService.UpdateStatus(id);
                _categoryService.Save();
                return new OkObjectResult(id);
            }
        }
    }
}