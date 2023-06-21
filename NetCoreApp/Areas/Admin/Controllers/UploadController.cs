using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
       

        //[HttpPost("file/upload")]
        //[Produces("application/json")]
        //public async Task<IActionResult> Post(IFormFile file)
        //{

        //    var filess = Request.Form.Files;

        //    // Get the file from the POST request
        //    var theFile = filess.FirstOrDefault();

        //    // Get the server path, wwwroot
        //    string webRootPath = _hostingEnvironment.WebRootPath;

        //    var fileRoute = Path.Combine(webRootPath, "uploads");


        //    string fullPath = Path.Combine(fileRoute, theFile.FileName);

        //    // Create directory if it does not exist.
        //    FileInfo dir = new FileInfo(fullPath);
        //    if (!dir.Exists)
        //    {
        //        dir.Directory.Create();
        //    }
        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        await theFile.CopyToAsync(stream);
        //    }

        //    string AppBaseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";


        //    return Ok(new
        //    {
        //        success = true,
        //        data = new
        //        {
        //            files = new[] { theFile.FileName },
        //            baseurl = $"{AppBaseUrl}/uploads/",
        //            message = "",
        //            error = "",
        //            path = $"{AppBaseUrl}/uploads/{theFile.FileName}"
        //        }
        //    });


        //}

        //[HttpPost]
        //public async Task<IActionResult> Jodit()
        //{
        //    if (Request.Form.Files != null && Request.Form.Files.Count > 0)
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        Request.Form.Files[0].CopyTo(ms);
        //        // upload file to storage
        //        // fileUrl looks like http://storagehost.com/c5o8mi34unc78rxe956.jpg
        //        var fileUrl = await SaveToStorageAsync(ms, Request.Form.Files[0].FileName);
        //        return Ok(new
        //        {
        //            success = true,
        //            data = new
        //            {
        //                files = new[] { fileUrl.Split('/').Last() },
        //                baseurl = settings.storageUrl, // http://storagehost.com
        //            }
        //        });
        //    }
        //    return BadRequest();
        //}


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
