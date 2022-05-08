using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        bool IsExists(string email);
        User GetUserByName(string name);
    }
}
