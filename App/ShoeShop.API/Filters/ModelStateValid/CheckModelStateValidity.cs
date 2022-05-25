using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

namespace ShoeShop.API.Filters.ModelStateValid
{
    public class CheckModelStateValidity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                next.Invoke();
            }
            else
            {
                context.Result = new BadRequestObjectResult(new { message = context.ModelState });
            }
        }
    }
}
