using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Entities;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductService _productManager;
        private readonly IMemoryCache _cache;

        public HomeController(IProductService productService, IMemoryCache cache)
        {
            _productManager = productService;
            _cache = cache;
        }



        [HttpGet]
        public async Task<IActionResult> GetProducts(int page, string catName, int genderID, int brandID, int colorID, int updateState)
        {
            var isInCache = _cache.TryGetValue("Prodts", out IEnumerable<ProductDto> cachedProdts);
            if (!isInCache)
            {
                var products = catName == null ? _productManager.GetAllActiveProductsWithBrand() : catName == "-1" ? _productManager.GetAllActiveProductsWithBrand() :
                    _productManager.GetAllActiveProductsWithBrand().Where(p => p.CategoryName == catName).ToList();
                products = genderID == null ? products : genderID == -1 || genderID == 0 ? products : products.Where(p => p.GenderID == genderID).ToList();
                products = brandID == null ? products : brandID == -1 || brandID == 0 ? products : products.Where(p => p.BrandID == brandID).ToList();
                products = colorID == null ? products : colorID == -1 || colorID == 0 ? products : products.Where(p => p.ColorID == colorID).ToList();

                var productsPerPage = 6;
                var paginatedProducts = products.OrderBy(x => x.Name)
                    .Skip((page - 1) * productsPerPage)
                    .Take(productsPerPage);
                cachedProdts = paginatedProducts;
                _cache.Set("Categories", paginatedProducts, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            
            return Ok(cachedProdts);
        }

    }
}
