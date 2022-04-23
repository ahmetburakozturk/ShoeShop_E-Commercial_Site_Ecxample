using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoeShop.Businness.Abstract;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger,IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int page,string catName)
        {
            var categories = _categoryService.GetAllCategories().ToList().Where(c => c.Name == catName);
            var category = categories.LastOrDefault();
            var products = catName != null
                ? _productService.GetAllProductsWithInfo().Where(p => p.CategoryName == catName).ToList()
                : _productService.GetAllProductsWithInfo();
            //var products = _productService.GetAllProducts();
            var productsPerPage = 8;
            var paginatedProducts = products.OrderBy(x => x.Name)
                .Skip((page - 1) * productsPerPage)
               .Take(productsPerPage);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentCategory = catName;
            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / productsPerPage);
            return View(paginatedProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
