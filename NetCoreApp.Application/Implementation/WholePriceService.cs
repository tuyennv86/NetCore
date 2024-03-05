using AutoMapper;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Application.ViewModels.Product;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApp.Application.Implementation
{
    public class WholePriceService : IWholePriceService
    {
        private readonly IWholePriceRepository _wholePriceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WholePriceService(IWholePriceRepository wholePriceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _wholePriceRepository = wholePriceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public WholePriceViewMode Add(WholePriceViewMode wholePriceViewMode)
        {
            var entity = _mapper.Map<WholePriceViewMode, WholePrice>(wholePriceViewMode);
            _wholePriceRepository.Add(entity);
            return wholePriceViewMode;
        }

        public void Delete(int Id)
        {
            _wholePriceRepository.Remove(Id);
        }

        public void DeleteByProductId(int ProductID)
        {
            var entities = _wholePriceRepository.FindAll(x => x.ProductId == ProductID).ToList();
            _wholePriceRepository.RemoveMultiple(entities);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public WholePriceViewMode GetById(int Id)
        {
            return _mapper.Map<WholePrice, WholePriceViewMode>(_wholePriceRepository.FindById(Id));
        }

        public List<WholePriceViewMode> GetByProductID(int ProductID)
        {
            return _mapper.ProjectTo<WholePriceViewMode>(_wholePriceRepository.FindAll(x => x.ProductId)).ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(WholePriceViewMode wholePriceViewMode)
        {
            var entity = _mapper.Map<WholePriceViewMode, WholePrice>(wholePriceViewMode);
            _wholePriceRepository.Update(entity);
        }
    }
}
