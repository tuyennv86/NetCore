using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            userService = _userService;
            unitOfWork = _unitOfWork;
            mapper = _mapper;
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
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }else
            {
                if(userVm.Id == null)
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
                await _userService.DeleteAsync(id);
                return new OkObjectResult(id);
            }    
        }
    }
}
