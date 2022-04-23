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
            throw new NotImplementedException();
        }

        public int Update(Brand entity)
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
    }
}
