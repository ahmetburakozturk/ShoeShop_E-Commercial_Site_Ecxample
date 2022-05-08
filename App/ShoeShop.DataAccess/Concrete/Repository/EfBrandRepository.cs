using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfBrandRepository : IBrandRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfBrandRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Brand> GetAll()
        {
            return _dbContext.Brands.ToList();
        }

        public Brand GetById(int id)
        {
            return _dbContext.Brands.Find(id);
        }

        public int Add(Brand entity)
        {
            _dbContext.Brands.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;   
        }

        public int Update(Brand entity)
        {
            _dbContext.Brands.Update(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public void DeleteById(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(b => b.ID == id);
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Brands.Any(b => b.ID == id);
        }
    }
}
