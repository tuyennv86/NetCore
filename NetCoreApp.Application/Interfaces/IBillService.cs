using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Enums;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace NetCoreApp.Application.Interfaces
{
    public interface IBillService: IDisposable
    {
        PagedResult<BillViewModel> GetAllPageding(Status status, BillStatus billStatus, string customerName, string customerAddress, string customerMobile, int pageIndex, int pageSize);
        void UpdateStatus(int id, Status status);
        void UpdateBillStatus(int id, BillStatus billStatus);
        void Delete(int id);
        BillViewModel Add(BillViewModel billViewModel, List<BillDetailViewModel> billDetailViewModels);
        void Save();
    }
}
