using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor.Parser.SyntaxTree;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfFavoriteRepository : IFavoriteRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfFavoriteRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Favorite> GetAll()
        {
            return _dbContext.Favorites.ToList();
        }

        public Favorite GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Favorite entity)
        {
            _dbContext.Favorites.Add(entity);
            _dbContext.SaveChanges();
            return 1;
        }

        public int Update(Favorite entity)
        {
            _dbContext.Favorites.Update(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsFavorite(int userID, int productID)
        {
            var fav = _dbContext.Favorites.Where(f => f.UserID == userID && f.ProductID == productID).FirstOrDefault();
            return fav.IsFavorite;
        }

        public void RemoveFav(int userId, int productId)
        {
            var entity = _dbContext.Favorites.ToList().Where(f=>f.ProductID == productId && f.UserID == userId);
            foreach (var fav in entity)
            {
                _dbContext.Favorites.Remove(fav);
            }
            _dbContext.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Favorites.Any(f => f.ProductID == id);
        }

        public List<int> GetFavoriteProductsId(int userId)
        {
            List<int> favoriteProducts = new List<int>();
            var favorites = _dbContext.Favorites.Where(f => f.UserID == userId);
            foreach (var fav in favorites)
            {
                favoriteProducts.Add(fav.ProductID);
            }
            return favoriteProducts;
        }
    }
}
