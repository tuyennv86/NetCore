using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Application.Implementation;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Enums;

namespace NetCoreApp.Areas.Admin.Controllers
{
    public class BillController : BaseController
    {
        private readonly BillService _billService;
        public BillController(BillService billService)
        {
            _billService = billService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetByID(int id)
        {
            var model = _billService.GetById(id);
            return new OkObjectResult(model);
        }
        [HttpGet]
        public IActionResult GetAllPageding(Status status, BillStatus billStatus, string customerName, string customerAddress, string customerMobile,
           string startDate, string endDate, int pageIndex, int pageSize)
        {
            var model = _billService.GetAllPageding(status, billStatus, customerName, customerAddress, customerMobile,startDate, endDate, pageIndex, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPatch]
        public IActionResult UpdateStatus(int id, Status status)
        {
            _billService.UpdateStatus(id, status);
            _billService.Save();
            return new OkResult();
        }

        [HttpPatch]
        public IActionResult UpdateBillStatus(int id, BillStatus billStatus)
        {
            _billService.UpdateBillStatus(id, billStatus);
            _billService.Save();
            return new OkResult();
        }
        [HttpPost]
        public IActionResult Add(BillViewModel billViewModel)
        {
            _billService.Add(billViewModel);
            _billService.Save();
            return new OkObjectResult(billViewModel);
        }

    }
}
