using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoeShop.Businness.Abstract;
using ShoeShopWeb.Models;

namespace ShoeShopWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int id)
        {
            if (_productService.isExist(id))
            {
                var product = _productService.GetProductById(id);
                CartCollection cartCollection = getCollectionFromSession();
                cartCollection.Add(new CartItem { Product = product, Quantity = 1 });
                saveToSession(cartCollection);
                return Json($"{product.Name} Sepete Eklendi");
            }

            return NotFound("Bu Ürün Bulunamadı!");
        }

        private void saveToSession(CartCollection cartCollection)
        {
            throw new System.NotImplementedException();
        }

        private CartCollection getCollectionFromSession()
        {
            CartCollection cartCollection = null;
            if (HttpContext.Session.GetString("sepetim") == null)
            {
                cartCollection = new CartCollection();
            }
            else
            {
                var cartCollectionJson = HttpContext.Session.GetString("sepetim");
                JsonConvert.DeserializeObject<CartCollection>(cartCollectionJson); 
            }


            return cartCollection;
        }
    }
}
