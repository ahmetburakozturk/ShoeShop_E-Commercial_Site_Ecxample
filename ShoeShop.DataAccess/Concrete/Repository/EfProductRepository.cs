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
             _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public int Update(Product entity)
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

        public IList<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }


        public IList<Product> GetByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetBySize(int size)
        {
            throw new NotImplementedException();
        }
    }
}
