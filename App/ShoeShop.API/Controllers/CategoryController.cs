using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    //[Authorize(Roles = "admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryManager;
        private readonly IMemoryCache _cache;
        public CategoryController(ICategoryService categoryService, IMemoryCache cache)
        {
            _categoryManager = categoryService;
            _cache = cache;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Show()
        {
            var isInCache = _cache.TryGetValue("Categories", out List<Category> cachedCats);
            if (!isInCache)
            {
                var categories = _categoryManager.GetAllCategories().OrderBy(c => c.ID).ToList();
                cachedCats = categories;
                _cache.Set("Categories", categories, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            return Ok(cachedCats);  
        }



        [HttpGet("[action]")]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" }, VaryByHeader = "User-Agent",
            Location = ResponseCacheLocation.Client)]
        [CategoryIsExists]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            return Ok(category);
        }


        [HttpPost("Add")]
        [ModelStateIsValid]
        public IActionResult Create(CategoryDto categoryDto)
        {
            var lastCatId = _categoryManager.AddCategory(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), routeValues: new { id = lastCatId }, null);
        }


        [HttpPut("Update/")]
        [CategoryIsExists]
        [ModelStateIsValid]
        public IActionResult Edit(CategoryDto categoryDto)
        {
            _categoryManager.UpdateCategory(categoryDto);
            return Ok();
        }

        [HttpDelete("Delete/{id:int}")]
        [CategoryIsExists]
        public IActionResult Delete(int id)
        {
            _categoryManager.DeleteCategoryById(id);
            return Ok();
        }


        [HttpGet("GetCategoriesListForDropdown")]
        public IActionResult GetCategoriesForDropdown()
        {
            var isInCache = _cache.TryGetValue("Categoryİtems", out List<SelectListItem> cachedCategoryItems);
            if (!isInCache)
            {
                var selectedItems = new List<SelectListItem>();
                _categoryManager.GetAllCategories().ToList().ForEach(cat => selectedItems.Add(new
                    SelectListItem
                    { Text = cat.Name, Value = cat.ID.ToString() }
                ));
                cachedCategoryItems = selectedItems;
                _cache.Set("Colorsİtem", selectedItems, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
                });
            }

            
            return Ok(cachedCategoryItems);
        }
    }
}
