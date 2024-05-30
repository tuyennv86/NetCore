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
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;

        public ProductController(IProductService productService, ICategoryTypeService categoryTypeService, 
            ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment, IProductImageService productImageService, 
            IProductTagService productTagService, IProductQuantityService productQuantityService, IWholePriceService wholePriceService,
            IColorService colorService, ISizeService sizeService
            )
        {
            _productService = productService;
            _productImageService = productImageService;
            _categoryTypeService = categoryTypeService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _productTagService = productTagService;
            _productQuantityService = productQuantityService;
            _wholePriceService = wholePriceService;
            _colorService = colorService;
            _sizeService = sizeService;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllColor()
        {
            var data = _colorService.GetAll();
            return new OkObjectResult(data);
        }
        [HttpGet]
        public IActionResult GetByIdColor(int id)
        {
            return new OkObjectResult(_colorService.GetById(id));
        }
        [HttpGet]
        public IActionResult GetByIdQuantity(int id)
        {
            return new OkObjectResult(_productQuantityService.GetById(id));
        }
        [HttpGet]
        public IActionResult GetAllSize()
        {
            return new OkObjectResult(_sizeService.GetAll());
        }
        [HttpGet]
        public IActionResult GetByIdSize(int id)
        {
            return new OkObjectResult(_sizeService.GetById(id));
        }
        [HttpGet]
        public IActionResult GetAllQuantityByProductId(int productId)
        {
            return new OkObjectResult(_productQuantityService.GetByProductId(productId));            
        }

        [HttpDelete]
        public IActionResult DeleteColor(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _colorService.Delete(id);
                _colorService.Save();
                return new ObjectResult(id);
            }
        }
        [HttpDelete]
        public IActionResult DeleteSize(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _sizeService.Delete(id);
                _sizeService.Save();
                return new ObjectResult(id);
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

        [HttpPost]
        public IActionResult UpdateStatus(int id)
        {
            _productService.UpdateStatus(id);
            _productService.Save();
            return new OkObjectResult(id);
        }
        [HttpPost]
        public IActionResult UpdateHomeFlag(int id)
        {
            _productService.UpdateHomeFlag(id);
            _productService.Save();
            return new OkObjectResult(id);
        }
        [HttpPost]
        public IActionResult UpdateHotFlag(int id)
        {
            _productService.UpdateHotFlag(id);
            _productService.Save();
            return new OkObjectResult(id);
        }

        [HttpPost]
        public IActionResult UpdateOrder(int id, int order, int homeOrder)
        {
            _productService.UpdateOrder(id, order, homeOrder);
            _productService.Save();
            return new OkObjectResult(id);
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
                var model = _productService.GetById(id);
                if (!string.IsNullOrEmpty(model.Image))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + model.Image);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }
                _productService.UpdateImageEmpty(id);
                _productService.Save();
                return new OkObjectResult(id);
            }
        }
        [HttpDelete]
        public IActionResult DeleteImageProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                var imageProduct = _productImageService.GetById(id);
                if (!string.IsNullOrEmpty(imageProduct.Path))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + imageProduct.Path);
                    }
                    catch (Exception ex) { _logger.LogError(ex.Message); }
                }
                _productImageService.Delete(id);
                _productService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpPost]
        public IActionResult AddEditColor(ColorViewModel colorViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                if(colorViewModel.Id > 0)
                {
                    _colorService.Update(colorViewModel);
                }else
                {
                    _colorService.Add(colorViewModel);
                }
                _colorService.Save();
                return new OkObjectResult(colorViewModel);
            }
        }

        [HttpPost]
        public IActionResult AddEditSize(SizeViewModel sizeViewModel)
        {
            if (sizeViewModel.Id > 0)
            {
                _sizeService.Update(sizeViewModel);
            }
            else
            {
                _sizeService.Add(sizeViewModel);
            }
            _sizeService.Save();
            return new OkObjectResult(sizeViewModel);
        }

        [HttpPost]
        public IActionResult AddEditQuantity(ProductQuantityViewModel productQuantityViewModel)
        {
            if(productQuantityViewModel.Id > 0)
            {
                _productQuantityService.Update(productQuantityViewModel);
            }
            else
            {
                _productQuantityService.Add(productQuantityViewModel);
            }
            _productQuantityService.Save();
            return new OkObjectResult(productQuantityViewModel);
        }
        [HttpPost]
        public IActionResult DeleteQuantity(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _productQuantityService.Delete(id);
                _productQuantityService.Save();
                return new ObjectResult(id);
            }
        }

    }
}
