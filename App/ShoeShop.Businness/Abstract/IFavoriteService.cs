using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Abstract
{
    public interface IFavoriteService
    {
        void AddFavorite(int productID,int userID);
        List<int> GetFavoritesIdByUser(int userId); 
        void RemoveFavorite(int userId, int productId);
        bool IsExist(int id);
        List<int> GetFavoriteProductsId(int userId);
    }
}
