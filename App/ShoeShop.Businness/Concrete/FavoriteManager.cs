using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteManager(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public void AddFavorite(int productID, int userID)
        {
            var fav = new Favorite { ProductID = productID, UserID = userID,IsFavorite = true};
            _favoriteRepository.Add(fav);
        }
  
        public List<int> GetFavoritesIdByUser(int userId)
        {
            List<int> favorites = new List<int>();
            var favs = _favoriteRepository.GetAll().Where(f=>f.UserID==userId);
            foreach (var fav in favs)
            {
                favorites.Add(fav.ProductID);
            }
            return favorites;
        }

        public void RemoveFavorite(int userId, int productId)
        {
            _favoriteRepository.RemoveFav(userId,productId);
        }

        public bool IsExist(int id)
        {
            return _favoriteRepository.IsExists(id);
        }

        public List<int> GetFavoriteProductsId(int userId)
        {
            return _favoriteRepository.GetFavoriteProductsId(userId);
        }
    }
}
