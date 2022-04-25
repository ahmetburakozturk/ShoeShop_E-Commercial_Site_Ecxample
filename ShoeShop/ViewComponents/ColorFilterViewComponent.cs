using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;

namespace ShoeShopWeb.ViewComponents
{
    public class ColorFilterViewComponent : ViewComponent
    {
        private readonly IColorService _colorService;

        public ColorFilterViewComponent(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IViewComponentResult Invoke()
        {
            var colors = _colorService.GetAllColors().OrderBy(c => c.Name);
            return View(colors);
        }
    }
}
