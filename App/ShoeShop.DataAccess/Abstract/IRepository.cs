using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Abstract;

namespace ShoeShop.DataAccess.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Update(T entity);
        void DeleteById(int id);

    }
}
