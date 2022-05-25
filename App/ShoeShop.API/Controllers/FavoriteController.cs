using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using ShoeShop.API.Filters.IsExist;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteManager;
        private readonly IProductService _productManager;
        private readonly IMemoryCache _cache;
        private readonly IUserService _userManager;

        public FavoriteController(IFavoriteService favoriteService, IProductService productService, IMemoryCache cache, IUserService userService)
        {
            _favoriteManager = favoriteService;
            _productManager = productService;
            _cache = cache;
            _userManager = userService;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show()
        {
            var userID = _userManager.GetUserByName(User.Identity.Name).ID;
            var favoriteProducts = GetFavoriteProducts(userID);
            return Ok(favoriteProducts);
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



        [HttpPost("Add/{id:int}")]
        [FavoriteIsExists]
        public async Task<IActionResult> AddFavorite(int id)
        {
            int userId = User.Identity.Name != null ? _userManager.GetUserByName(User.Identity.Name).ID : 0;
            _favoriteManager.AddFavorite(id, userId);
            return Ok();
        }


        [HttpDelete("Delete/{id:int}")]
        [FavoriteIsExists]
        public async Task<IActionResult> RemoveFavoite(int id)
        {
             int userId = User.Identity.Name != null ? _userManager.GetUserByName(User.Identity.Name).ID : 0;
            _favoriteManager.RemoveFavorite(userId, id);
            return Ok();
        }
    }
}
