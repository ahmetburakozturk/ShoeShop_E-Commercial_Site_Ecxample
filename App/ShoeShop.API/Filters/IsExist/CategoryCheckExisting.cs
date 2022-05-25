using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoeShop.Businness.Abstract;

namespace ShoeShop.API.Filters.IsExist
{
    public class CategoryCheckExisting : IAsyncActionFilter
    {
        private readonly ICategoryService _categoryManager;

        public CategoryCheckExisting(ICategoryService categoryService)
        {
            _categoryManager = categoryService;
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
                if (_categoryManager.isExist(id))
                {
                    next.Invoke();
                }

                context.Result = new BadRequestObjectResult(new { message = $"{id} id'li kategori bulunamadı!" });
            }
        }
    }
}
