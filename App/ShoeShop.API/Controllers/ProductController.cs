using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ShoeShop.API.Filters.IsExist;
using ShoeShop.API.Filters.ModelStateValid;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Entities;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productManager;
        private readonly IMemoryCache _cache;
        private readonly IGenderService _genderManager;
        private readonly IColorService _colorManager;

        public ProductController(IProductService productService, IMemoryCache cache,
            IColorService colorService, IGenderService genderService)
        {
            _productManager = productService;
            _cache = cache;
            _colorManager = colorService;
            _genderManager = genderService;
        }


        [HttpPost("Add/Product")]
        [ModelStateIsValid]
        public async Task<IActionResult> AddProduct(ProductDto productResponse)
        {
            var lastProductId = _productManager.CreateProduct(productResponse);
            var products = _productManager.GetAllProducts();
            _cache.Set("ProductsShow", products, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5)
            });
            return CreatedAtAction(nameof(GetProductById), routeValues: new { id = lastProductId }, null);
        }


        [HttpGet("Show")]
        public IActionResult Show(int page)
        {

            var products = _productManager.GetAllProducts();
            var productsPerPage = 5;
            var paginatedProducts = products.OrderBy(x => x.ID)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage);
            return Ok(paginatedProducts);
        }


        [HttpPut("Update/{id:int}")]
        [IsExists]
        [ModelStateIsValid]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto updateProductRequest)
        {
            _productManager.UpdateProduct(updateProductRequest);
            return Ok();
        }


        [HttpPut("SoftDelete/{id:int}")]
        [IsExists]
        [ModelStateIsValid]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _productManager.GetProductById(id);
            _productManager.SoftDelete(product);
            return Ok();
        }




        [HttpGet("GetColorsListForDropdown")]
        public IActionResult GetColorsForDropdown()
        {
            var isInCache = _cache.TryGetValue("Colorsİtem", out List<SelectListItem> cachedColorsİtem);
            if (!isInCache)
            {
                var selectedItems = new List<SelectListItem>();
                _colorManager.GetAllColors().ToList().ForEach(col => selectedItems.Add(new
                    SelectListItem
                    { Text = col.Name, Value = col.ID.ToString() }
                ));
                cachedColorsİtem = selectedItems;
                _cache.Set("Colorsİtem", selectedItems, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            
            return Ok(cachedColorsİtem);
        }



        [HttpGet("GetGendersListForDropdown")]
        public IActionResult GetGendersForDropdown()
        {
            var isInCache = _cache.TryGetValue("Genderİtems", out List<SelectListItem> cachedGenderItems);
            if (!isInCache)
            {
                var selectedItems = new List<SelectListItem>();
                _genderManager.GetAllGenders().ToList().ForEach(gen => selectedItems.Add(new
                    SelectListItem
                    { Text = gen.Name, Value = gen.ID.ToString() }
                ));
                cachedGenderItems = selectedItems;
                _cache.Set("Genderİtems", selectedItems, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            
            return Ok(cachedGenderItems);
        }


        [AllowAnonymous]
        [HttpGet("[action]")]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" }, VaryByHeader = "User-Agent",
            Location = ResponseCacheLocation.Client)]
        [IsExists]
        public IActionResult GetProductById(int id)
        {
            var product = _productManager.GetProductById(id);
            return Ok(product);
        }
    }
}
