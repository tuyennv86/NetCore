﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;
        //private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
          
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
                //if (entity.filesImg != null)
                //{   
                //    string pathPhoto = Path.Combine(_hostingEnvironment.WebRootPath, $@"\Uploaded\Images\{DateTime.Now:yyyyMMdd}");
                //    if (!Directory.Exists(pathPhoto))
                //    {
                //        Directory.CreateDirectory(pathPhoto);
                //    }
                //    string photoName = Path.GetFileName(entity.filesImg.FileName);
                //    using (FileStream stream = new FileStream(Path.Combine(pathPhoto, photoName), FileMode.Create))
                //    {
                //        entity.filesImg.CopyTo(stream);
                //    }                    
                //}

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (entity.Id == 0)
                {
                    entity.CreateById = userId;
                    entity.EditById = userId;
                    entity.DateCreated = System.DateTime.Now;
                    entity.DateModified = System.DateTime.Now;
                    _categoryService.Add(entity);
                }
                else
                {
                    entity.EditById = userId;
                    entity.DateModified = System.DateTime.Now;
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
    }
}