using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoeShop.Dtos;

namespace ShoeShop.Businness.Abstract
{
    public interface IStockService
    {
        ICollection<StockDto> GetSizes(int productId);

        void AddStock(StockDto stock);
    }
}
