using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Abstract
{
    public interface IUserService
    {
        UserDto GetUser(string email);  
        bool IsExist(string email); 
        void AddUser(UserDto user); 
        UserDto ValidateUser(string email, string password);    
        UserDto GetUserByName(string name);
    }
}
