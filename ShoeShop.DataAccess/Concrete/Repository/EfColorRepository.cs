using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfColorRepository : IColorRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfColorRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Color> GetAll()
        {
            return _dbContext.Colors.ToList();
        }

        public Color GetById(int id)
        {
            return _dbContext.Colors.Find(id);
        }

        public int Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Color entity)
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
