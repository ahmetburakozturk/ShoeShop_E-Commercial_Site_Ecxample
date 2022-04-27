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

        public IActionResult Index(int page,string? catName,int? genderID, int? brandID, int? colorID)
        {
            var products = catName != null
                ? _productService.GetAllActiveProductsWithBrand().Where(p => p.CategoryName == catName).ToList()
                : _productService.GetAllActiveProductsWithBrand();
            products = genderID != null ? products.Where(p => p.GenderID == genderID).ToList() : products;
            products = brandID != null ? products.Where(p => p.BrandID == brandID).ToList() : products;
            products = colorID != null ? products.Where(p => p.ColorID == colorID).ToList() : products;
            var productsPerPage = 8;
            var paginatedProducts = products.OrderBy(x => x.Name)
                .Skip((page - 1) * productsPerPage)
               .Take(productsPerPage);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentCategory = catName;
            ViewBag.CurrentGender = genderID;
            ViewBag.CurrentBrandID = brandID;
            ViewBag.CurrentColorID = colorID;
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
