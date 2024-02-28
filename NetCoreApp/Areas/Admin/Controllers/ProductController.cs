using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{   
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly ICategoryTypeService _categoryTypeService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(IProductService productService, ICategoryTypeService categoryTypeService, ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _categoryTypeService = categoryTypeService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int? id)
        {            
            // ceck nếu có id thì lấy thông tin categoryType trả về view
            int typeId = (int)(id == null ? 0 : id);
            var model = _categoryTypeService.GetById(typeId);
            if (model == null)
            {
                CategoryTypeViewModel model1 = new();
                return View(model1);
            }
            return View(model);
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
            return new OkObjectResult(model);
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
                    var entity = _productService.GetById(id);
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        //xóa lịch trình tour TourDate
                        //_tourDateService.DeleteByTourID(id);
                        ////xóa danh sách các ảnh liên quan Images
                        //var images = _imagesService.GetAll(id);
                        //foreach (TourImagesViewModel image in images)
                        //{
                        //    if (!string.IsNullOrEmpty(image.Name))
                        //    {
                        //        try
                        //        {
                        //            System.IO.File.Delete(_hostingEnvironment.WebRootPath + image.Name);
                        //        }
                        //        catch (Exception ex) { _logger.LogError(ex.Message); }
                        //    }
                        //}
                        //_imagesService.DeleteByTourId(id);
                        //xóa ảnh đại diện dang sách tour
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                }
                _productService.DeleteAll(listId);
                //_tourDateService.Save();
                //_imagesService.Save();
                //_tourService.Save();
                return new OkObjectResult(listId);
            }
        }
    }
}
