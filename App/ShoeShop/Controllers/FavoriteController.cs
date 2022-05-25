using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Dtos;
using ShoeShop.Businness.Abstract;


namespace ShoeShopWeb.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteManager;
        private readonly IProductService _productManager;
        private readonly IUserService _userManager;

        public FavoriteController(IFavoriteService favoriteService, IProductService productService, IUserService userService)
        {
            _favoriteManager = favoriteService;
            _productManager = productService;
            _userManager = userService;
        }
        public IActionResult Show()
        {
            var userID = _userManager.GetUserByName(User.Identity.Name).ID;
            var favoriteProducts = GetFavoriteProducts(userID);
            return View(favoriteProducts);
        }

        private List<ProductDto> GetFavoriteProducts(int userID)
        {
            var productsId = _favoriteManager.GetFavoriteProductsId(userID);
            var favoriteProducts = new List<ProductDto>();
            foreach (var id in productsId)
            {
                favoriteProducts.Add(_productManager.GetProductById(id));
            }
            return favoriteProducts;
        }

        public IActionResult AddFavorite(int id)
        {
            if (_productManager.isExist(id))
            {
                int userId = User.Identity.Name != null ? _userManager.GetUserByName(User.Identity.Name).ID : 0;
                if (!_favoriteManager.IsExist(id))
                {
                    _favoriteManager.AddFavorite(id, userId);
                    return Json("Favorilere Eklendi");
                }

                return Json("Ürün zaten favorilerde!");
            }

            return NotFound("Bu Ürün Bulunamadı!");
        }

        public IActionResult RemoveFavorite(int id)
        {
            if (_favoriteManager.IsExist(id))
            {
                int userId = User.Identity.Name != null ? _userManager.GetUserByName(User.Identity.Name).ID : 0;
                _favoriteManager.RemoveFavorite(userId,id);
                return Json("Favorilerden Çıkartıldı");
            }

            return Json("Ürün Bulunamadı!");
        }
    }
}
