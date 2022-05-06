using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfCategoryRepository :ICategoryRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfCategoryRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public int Add(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public int Update(Category entity)
        {
            _dbContext.Categories.Update(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public void DeleteById(int id)
        {
            var cagtegory = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(cagtegory);
            _dbContext.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Categories.Any(p => p.ID == id);
        }
    }
}
