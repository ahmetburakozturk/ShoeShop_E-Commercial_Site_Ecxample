using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoeShop.Businness.Abstract;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

namespace ShoeShop.API.Filters.IsExist
{
    public class CheckExisting : IAsyncActionFilter
    {
        private readonly IProductService _productManager;

        public CheckExisting(IProductService productService)
        {
            _productManager = productService;
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
                if (_productManager.isExist(id))
                {
                    next.Invoke();
                }

                context.Result = new BadRequestObjectResult(new { message = $"{id} id'li ürün bulunamadı!" });
            }
        }
    }
}
