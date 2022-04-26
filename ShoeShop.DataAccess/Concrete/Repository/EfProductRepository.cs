using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfProductRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Product> GetAll()
        {
            return _dbContext.Products.ToList(); ;
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public int Add(Product entity)
        {
            entity.Discount = entity.Discount / 10;
            entity.Discount = entity.Discount / 10;
             _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public int Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Products.Any(p => p.ID == id);
        }

    }
}
