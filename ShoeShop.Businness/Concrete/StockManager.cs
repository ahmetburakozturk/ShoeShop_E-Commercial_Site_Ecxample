using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos;

namespace ShoeShop.Businness.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockManager(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public ICollection<StockDto> GetSizes(int productId)
        { 
            return _stockRepository.GetSizes(productId);
        }
    }
}
