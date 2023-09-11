using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace NetCoreApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _userService.GetAllAsync();
            return new OkObjectResult(models);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            var models = _userService.GetAllPagingAsync(keyword, pageIndex, pageSize);
            return new OkObjectResult(models);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string Id)
        {
            var model = await _userService.GetById(Id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(AppUserViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }else
            {
                if (userVm.filesImg != null)
                {
                    string pathPhoto = $@"\Uploaded\Images\{DateTime.Now:yyyyMMdd}";
                    string folder = _hostingEnvironment.WebRootPath + pathPhoto;
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string photoName = Path.GetFileName(userVm.filesImg.FileName);
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
                    userVm.filesImg.CopyTo(stream);
                    stream.Flush();
                    userVm.Avatar = Path.Combine(pathPhoto, photoName);
                    // Nếu update thì xóa ảnh đang có
                    if(userVm.Id != null)
                    {
                        var entity = await _userService.GetById(userVm.Id.ToString());
                        if (!string.IsNullOrEmpty(entity.Avatar))
                        {
                            try
                            {
                                System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Avatar);
                            }
                            catch (Exception ex) { string s = ex.Message; }
                        }
                    }
                }

                if (userVm.Id == null)
                {                    
                    await _userService.AddAsync(userVm);                   
                }else
                {
                    await _userService.UpdateAsync(userVm);
                }
                return new OkObjectResult(userVm);
            }    
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }else
            {
                var entity = await _userService.GetById(id);
                if (!string.IsNullOrEmpty(entity.Avatar))
                {
                    try
                    {
                        System.IO.File.Delete(_hostingEnvironment.WebRootPath + entity.Avatar);
                    }
                    catch (Exception ex) {
                        _ = ex.Message;
                    }
                }
                await _userService.DeleteAsync(id);                 
                return new OkObjectResult(id);
            }    
        }
    }
}
