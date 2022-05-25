using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.API.Filters.ModelStateValid;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockManager;
        private readonly IProductService _productManager;

        public StockController(IStockService stockService, IProductService productService)
        {
            _stockManager = stockService;
            _productManager = productService;
        }


        [HttpPost("Add")]
        [ModelStateIsValid]
        public async Task<IActionResult> AddStock(StockDto stockDto)
        {
            _stockManager.AddStock(stockDto);
            return Ok();
        }
    }
}
