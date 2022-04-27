using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Businness.Abstract;
using ShoeShop.Entities;

namespace ShoeShopWeb.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Show()
        {
            var brands = _brandService.GetAllBrands().OrderBy(b=>b.Name);
            return View(brands);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_brandService.IsExist(id))
            {
                var brand = _brandService.GetBrand(id);
                return View(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.UpdateBrand(brand);
                return RedirectToAction(nameof(Show), nameof(Brand));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.AddBrand(brand);
                return RedirectToAction(nameof(Show), nameof(Brand));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_brandService.IsExist(id))
            {
                var brand = _brandService.GetBrand(id);
                return View(brand);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            if (_brandService.IsExist(brand.ID))
            {
                _brandService.DeleteBrand(brand.ID);
                return RedirectToAction(nameof(Show), nameof(brand));
            }

            return View();
        }
    }
}
