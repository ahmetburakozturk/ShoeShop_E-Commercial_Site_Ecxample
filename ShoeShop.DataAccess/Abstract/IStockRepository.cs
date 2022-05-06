using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoeShop.Dtos;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Abstract
{
    public interface IStockRepository : IRepository<Stock>
    {
        ICollection<StockDto> GetSizes(int id);
    }
}
