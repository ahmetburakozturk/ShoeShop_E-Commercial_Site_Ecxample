using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoeShop.Businness.Abstract;
using ShoeShopWeb.Extensions;
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
        public IActionResult Basket()
        {
            var cartCollection = getCollectionFromSession();
            return View(cartCollection);
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
            HttpContext.Session.SetJson("sepetim",cartCollection);
        }

        private CartCollection getCollectionFromSession()
        {
            CartCollection cartCollection = null;
            cartCollection = HttpContext.Session.GetJson<CartCollection>("sepetim") ?? new CartCollection();
            return cartCollection;
        }

        public IActionResult Delete(int id)
        {
            CartCollection cartCollection = getCollectionFromSession();
            cartCollection.Delete(id);
            saveToSession(cartCollection);
            return Json("Ürün Sepetten Çıkartıldı");
        }
    }
}
