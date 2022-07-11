using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using NetCoreApp.Extensions;
using NetCoreApp.Application.ViewModels.System;
using NetCoreApp.Utilities.Constants;

namespace NetCoreApp.Areas.Admin.Components
{
    public class SideMenuViewComponent:ViewComponent
    {
        private readonly IFunctionService _functionService;
        public SideMenuViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll(string.Empty);
            }else
            {
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}
