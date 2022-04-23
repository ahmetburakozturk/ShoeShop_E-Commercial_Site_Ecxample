using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos.Requests;

namespace ShoeShopWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IGenderService _genderService;

        public ProductsController(IProductService productService,ICategoryService categoryService,IBrandService brandService, IColorService colorService, IGenderService genderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _colorService = colorService;
            _genderService = genderService;
        }
        public IActionResult Show()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesForDropdown();
            ViewBag.Colors = GetColorsForDropdown();
            ViewBag.Brands = GetBrandsForDropdown();
            ViewBag.Genders = GetGendersForDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                var prodId = _productService.CreateProduct(productRequest);
                return RedirectToAction(nameof(Show));
            }

            return View();
        }

        private List<SelectListItem> GetCategoriesForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _categoryService.GetAllCategories().ToList().ForEach(cat => selectedItems.Add(new
                SelectListItem
                { Text = cat.Name, Value = cat.ID.ToString() }
            ));
            return selectedItems;
        }
        private List<SelectListItem> GetBrandsForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _brandService.GetAllBrands().ToList().ForEach(bnd => selectedItems.Add(new
                SelectListItem
                { Text = bnd.Name, Value = bnd.ID.ToString() }
            ));
            return selectedItems;
        }
        private List<SelectListItem> GetColorsForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _colorService.GetAllColors().ToList().ForEach(col => selectedItems.Add(new
                SelectListItem
                { Text = col.Name, Value = col.ID.ToString() }
            ));
            return selectedItems;
        }

        private List<SelectListItem> GetGendersForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            _genderService.GetAllGenders().ToList().ForEach(gen => selectedItems.Add(new
                SelectListItem
                { Text = gen.Name, Value = gen.ID.ToString() }
            ));
            return selectedItems;
        }

    }
}
