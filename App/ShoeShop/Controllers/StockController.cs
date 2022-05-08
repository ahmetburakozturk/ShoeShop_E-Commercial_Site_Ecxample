using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;

namespace ShoeShopWeb.Controllers
{
    [Authorize(Roles = "admin")]
    public class StockController : Controller
    {
        private readonly IStockService _stockManager;
        private readonly IProductService _productService;

        public StockController(IStockService stockService, IProductService productService)
        {
            _stockManager = stockService;
            _productService = productService;
        }
        public IActionResult Create()
        {
            ViewBag.Products = GetProductsForDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(StockDto stockDto)
        {
            if (ModelState.IsValid)
            {
                _stockManager.AddStock(stockDto);
                ViewBag.State = true;
                ViewBag.Products = GetProductsForDropdown();
                return View();
            }
            ViewBag.Products = GetProductsForDropdown();
            return View();
        }

        private List<SelectListItem> GetProductsForDropdown()
        {   
            var selectedItems = new List<SelectListItem>();
            _productService.GetAllProducts().ToList().ForEach(p => selectedItems.Add(new
                SelectListItem
                { Text = p.Name, Value = p.ID.ToString() }
            ));
            return selectedItems;
        }
    }
}
