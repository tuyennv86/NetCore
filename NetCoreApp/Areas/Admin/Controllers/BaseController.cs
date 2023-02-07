using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Extensions;

namespace NetCoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]   
    public class BaseController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
