using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.Enums;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NetCoreApp.Application.Implementation
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billReposotory;
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
       
        public BillService(IBillRepository billRepository, IBillDetailRepository billDetailRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _billReposotory = billRepository;
            _billDetailRepository = billDetailRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public BillViewModel Add(BillViewModel billViewModel)
        {
            var order = _mapper.Map<BillViewModel, Bill>(billViewModel);
            var orderDetails = _mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billViewModel.BillDetails);
            foreach (var detail in orderDetails)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
            }
            order.BillDetails = orderDetails;
            _billReposotory.Add(order);
            return billViewModel;
        }

        public void Delete(int id)
        {
            var billDetails = _billDetailRepository.FindAll(x => x.BillId == id).ToList();
            _billDetailRepository.RemoveMultiple(billDetails);

            _billReposotory.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public BillViewModel GetById(int id)
        {
            var model = _billReposotory.FindById(id);
            return _mapper.Map<Bill, BillViewModel>(model);
        }

        public PagedResult<BillViewModel> GetAllPageding(Status status, BillStatus billStatus, string customerName, string customerAddress, string customerMobile, string startDate, string endDate, int pageIndex, int pageSize)
        {
            var query = _billReposotory.FindAll();
            if (status != Status.All)
                query = query.Where(x => x.Status == status);
            if (billStatus != BillStatus.All)
                query = query.Where(x => x.BillStatus == billStatus);
            if (!string.IsNullOrEmpty(customerName))
                query = query.Where(x => x.CustomerName.Contains(customerName));
            if (!string.IsNullOrEmpty(customerAddress))
                query = query.Where(x => x.CustomerAddress.Contains(customerAddress));
            if (!string.IsNullOrEmpty(customerMobile))
                query = query.Where(x => x.CustomerMobile.Contains(customerMobile));
            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated <= start);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated <= end);
            }
            int totalRow = query.Count();
            query = query.OrderByDescending(x => x.DateCreated).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<BillViewModel>(query).ToList();

            var pageResult = new PagedResult<BillViewModel>()
            {
                Results = data,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return pageResult;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void UpdateBillStatus(int id, BillStatus billStatus)
        {
            var bill = _billReposotory.FindById(id);
            bill.BillStatus = billStatus;
            _billReposotory.Update(bill);
        }

        public void UpdateStatus(int id, Status status)
        {
            var bill = _billReposotory.FindById(id);
            bill.Status = status;
            _billReposotory.Update(bill);
        }        
    }
}
