using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfGenderRpository : IGenderRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfGenderRpository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Gender> GetAll()
        {
            return _dbContext.Genders.ToList();
        }

        public Gender GetById(int id)
        {
            return _dbContext.Genders.Find(id);
        }

        public int Add(Gender entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Gender entity)
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
