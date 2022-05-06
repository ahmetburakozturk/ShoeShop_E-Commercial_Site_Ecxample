using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoeShop.Businness.Abstract;
using ShoeShop.Entities;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index(int page,string? catName,int? genderID, int? brandID, int? colorID)
        {
            var products = catName == null ? _productService.GetAllActiveProductsWithBrand() : catName=="-1" ? _productService.GetAllActiveProductsWithBrand() :
                 _productService.GetAllActiveProductsWithBrand().Where(p => p.CategoryName == catName).ToList();

            products = genderID == null ? products : genderID == -1 ? products : products.Where(p => p.GenderID == genderID).ToList();

            products = brandID == null ? products : brandID == -1 ? products : products.Where(p => p.BrandID == brandID).ToList();


            products = colorID == null ? products : colorID == -1? products : products.Where(p => p.ColorID == colorID).ToList();

            var productsPerPage = 6;
            var paginatedProducts = products.OrderBy(x => x.Name)
                .Skip((page - 1) * productsPerPage)
               .Take(productsPerPage);
            var latesProducts = products.OrderByDescending(x => x.ID)
                .Take(productsPerPage);
            ViewBag.Latest = latesProducts;
            ViewBag.CurrentPage = page;
            ViewBag.CurrentCategory = catName;
            ViewBag.CurrentGenderID = genderID;
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
