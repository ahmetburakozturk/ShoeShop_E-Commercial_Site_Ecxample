using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockManager(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public ICollection<StockDto> GetSizes(int productId)
        { 
            return _stockRepository.GetSizes(productId);
        }

        public void AddStock(StockDto stock)
        {
            var newStock = _mapper.Map<Stock>(stock);
            _stockRepository.Add(newStock);
        }
    }
}
