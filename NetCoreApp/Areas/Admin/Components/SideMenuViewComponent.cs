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
using Microsoft.AspNetCore.Identity;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Areas.Admin.Components
{
    public class SideMenuViewComponent:ViewComponent
    {
        private readonly IFunctionService _functionService;
        private readonly RoleManager<AppRole> _roleManager;
        public SideMenuViewComponent(IFunctionService functionService, RoleManager<AppRole> roleManager)
        {
            _functionService = functionService;
            _roleManager = roleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");            

            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AppRole.AdminRole))
            {
                functions = await _functionService.GetAll(string.Empty);
            }else
            {
                string[] rolesArr = new string[roles.Split(';').Length];
                int i = 0;
                foreach (string roleName in roles.Split(';'))
                {
                    var role = _roleManager.FindByNameAsync(roleName).Result;
                    rolesArr[i] = role.Id.ToString();
                    i++;
                }

                functions = _functionService.GetAllByUser(rolesArr);

                //functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}
