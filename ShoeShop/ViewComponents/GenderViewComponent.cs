using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Businness.Abstract;

namespace ShoeShopWeb.ViewComponents
{
    public class GenderViewComponent : ViewComponent
    {
        private readonly IGenderService _genderService;

        public GenderViewComponent(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public IViewComponentResult Invoke()
        {
            var genders = _genderService.GetAllGenders().OrderBy(p => p.Name);
            return View(genders);
        }
    }
}
