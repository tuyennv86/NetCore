using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    
    public class FileManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
