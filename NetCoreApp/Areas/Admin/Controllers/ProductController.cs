using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly ICategoryTypeService _categoryTypeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductImageService _productImageService;
        private readonly IProductTagService _productTagService;
        private readonly IProductQuantityService _productQuantityService;
        private readonly IWholePriceService _wholePriceService;

        public ProductController(IProductService productService, ICategoryTypeService categoryTypeService, 
            ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment, IProductImageService productImageService, 
            IProductTagService productTagService, IProductQuantityService productQuantityService, IWholePriceService wholePriceService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _categoryTypeService = categoryTypeService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _productTagService = productTagService;
            _productQuantityService = productQuantityService;
            _wholePriceService = wholePriceService;
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
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                // delelet ProductImage
                var productImages = _productImageService.GetAllByProductID(id);
                foreach(ProductImageViewModel entity in productImages)
                {
                    if (!string.IsNullOrEmpty(entity.Path))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Path);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }
                }
               
                // delete image
                var product = _productService.GetById(id);
                if (!string.IsNullOrEmpty(product.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + product.Image);
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }
                }
                _productImageService.DeleteByProductId(id);

                // delete Tag
                _productTagService.DeleteByProductId(id);
                // delete ProductQuantity
                _productQuantityService.DeleteByProductId(id);
                // delete WholePrice
                _wholePriceService.DeleteByProductId(id);

                _productService.Delete(id);
                       
                _productService.Save();

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
                    var entity = _productService.GetById(id);
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Image);
                        }
                        catch (Exception ex) { _logger.LogError(ex.Message); }
                    }
                    // xóa thông tin liên quan
                    var productImages = _productImageService.GetAllByProductID(id);
                    foreach (ProductImageViewModel imgEntity in productImages)
                    {
                        if (!string.IsNullOrEmpty(imgEntity.Path))
                        {
                            try
                            {
                                System.IO.File.Delete(_hostingEnvironment.WebRootPath + imgEntity.Path);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.Message);
                            }
                        }
                    }

                    // delete image
                    var product = _productService.GetById(id);
                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        try
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + product.Image);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }
                    _productImageService.DeleteByProductId(id);
                    // delete Tag
                    _productTagService.DeleteByProductId(id);
                    // delete ProductQuantity
                    _productQuantityService.DeleteByProductId(id);
                    // delete WholePrice
                    _wholePriceService.DeleteByProductId(id);

                    _productService.Delete(id);
                }
                _productService.DeleteAll(listId);
                _productService.Save();
                return new OkObjectResult(listId);
            }
        }

        [HttpPost]
        public IActionResult SaveEntity(ProductViewModel entity)
        {
            if (ModelState.IsValid)
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
                List<ProductImageViewModel> listProductImages = new();
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
                        ProductImageViewModel productImage = new();

                        string ImagePath = Path.Combine(pathPhoto, photoName);
                        productImage.Path = ImagePath;
                        productImage.ProductId = entity.Id;

                        listProductImages.Add(productImage);
                    }
                }
                // hêt list ảnh 

                if (entity.Id == 0)
                {
                    entity.CreateById = new Guid(userId);
                    entity.EditById = new Guid(userId);
                    entity.DateModified = DateTime.Now;
                    _productService.Add(entity, listProductImages);
                }
                else
                {
                    entity.EditById = new Guid(userId);
                    entity.DateModified = DateTime.Now;
                    _productService.Update(entity, listProductImages);
                }

                _productService.Save();
                return new OkResult();
            }
        }

    }
}
