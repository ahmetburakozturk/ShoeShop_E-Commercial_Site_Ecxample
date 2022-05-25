using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ShoeShop.Dtos.Concrete;
using ShoeShop.Entities;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandManager;
        private readonly IMemoryCache _cache;

        public BrandController(IBrandService brandService, IMemoryCache cache)
        {
            _brandManager = brandService;
            _cache = cache;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetBrands()
        {
            var isInCache = _cache.TryGetValue("Brands", out IOrderedEnumerable<Brand> cachedBrands);
            if (!isInCache)
            {
                var brands = _brandManager.GetAllBrands().OrderBy(b => b.Name);
                cachedBrands = brands;
                _cache.Set("Brands", brands, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }
            return Ok(cachedBrands);
        }



        [HttpGet("[action]")]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" }, VaryByHeader = "User-Agent",
            Location = ResponseCacheLocation.Client)]
        [BrandIsExist]
        public IActionResult GetBrandById(int id)
        {
            var brand = _brandManager.GetBrand(id);
            return Ok(brand);
        }


        [HttpPost("Add")]
        [ModelStateIsValid]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            var lastBrandId = _brandManager.AddBrand(brand);
            return CreatedAtAction(nameof(GetBrandById), routeValues: new { id = lastBrandId }, null);
        }


        [HttpPut("Update/{id:int}")]
        [BrandIsExist]
        [ModelStateIsValid]
        public async Task<IActionResult> Update(int id, BrandDto brandDto)
        {
            _brandManager.UpdateBrand(brandDto);
            return Ok();
        }


        [HttpDelete("Delete/{id:int}")]
        [BrandIsExist]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            _brandManager.DeleteBrand(id);
            return Ok();
        }


        [HttpGet("GetBrandsListForDropdown")]
        public IActionResult GetBrandsForDropdown()
        {
            var isInCache = _cache.TryGetValue("Brandİtems", out List<SelectListItem> cachedBrandİtems);
            if (!isInCache)
            {
                var selectedItems = new List<SelectListItem>();
                _brandManager.GetAllBrands().ToList().ForEach(bnd => selectedItems.Add(new
                    SelectListItem
                    { Text = bnd.Name, Value = bnd.ID.ToString() }
                ));
                cachedBrandİtems = selectedItems;
                _cache.Set("Colorsİtem", selectedItems, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            
            return Ok(cachedBrandİtems);
        }
    }
}
