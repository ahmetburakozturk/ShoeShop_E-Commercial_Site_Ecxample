using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;

namespace ShoeShop.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        bool IsExists(int id);
    }
}
