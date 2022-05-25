using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoeShop.Businness.Abstract;

namespace ShoeShop.API.Filters.IsExist
{
    public class FavoriteCheckExisting : IAsyncActionFilter
    {
        private readonly IFavoriteService _favoriteManager;

        public FavoriteCheckExisting(IFavoriteService favoriteService)
        {
            _favoriteManager = favoriteService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idExist = context.ActionArguments.ContainsKey("id");
            if (!idExist)
            {
                context.Result = new BadRequestObjectResult(new { message = $"id parametresi bulunamadı!" });
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (_favoriteManager.IsExist(id))
                {
                    next.Invoke();
                }

                context.Result = new BadRequestObjectResult(new { message = $"{id} id'li ürün bulunamadı!" });
            }
        }
    }
}
