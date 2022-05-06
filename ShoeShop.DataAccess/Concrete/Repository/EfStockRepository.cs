using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfStockRepository : IStockRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfStockRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Stock> GetAll()
        {
            return _dbContext.Stocks.ToList();
        }

        public Stock GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Stock entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Stock entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<StockDto> GetSizes(int id)
        {
            var sizeList = new List<StockDto>();
            var innerJoin = from stk in _dbContext.Stocks
                where stk.ProductID == id
                select new
                {
                    Size = stk.Size,
                    ID = stk.ID,
                };
            foreach (var item in innerJoin)
            {
                var size = new StockDto
                {
                    SizeName = item.Size.ToString(),
                    StockID = item.ID,
                };
                sizeList.Add(size);
            }
            return sizeList;
        }
    }
}
