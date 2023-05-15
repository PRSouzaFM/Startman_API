using Microsoft.AspNetCore.Mvc;
using Starman.Interfaces;
using Starman.Models;

namespace Starman.Controllers
{
    [ApiController]
    [Route("api/stockitems")]
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemService stockItemService;

        public StockItemController(IStockItemService StockItemService)
        {
            this.stockItemService = StockItemService;
        }

        [HttpGet("{itemCode}")]
        public IActionResult GetStockItem(int itemCode)
        {
            var stockItem = stockItemService.GetStockItem(itemCode);
            if (stockItem == null)
            {
                return NotFound();
            }

            return Ok(stockItem);
        }

        [HttpGet]
        public IActionResult GetAllStockItems()
        {
            var stockItems = stockItemService.GetAllStockItems();
            return Ok(stockItems);
        }
        [HttpPost]
        public IActionResult AddStockItem(StockItem stockItem)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return a bad request
                return BadRequest(ModelState);
            }

            stockItemService.AddStockItem(stockItem);
            var stockItems = stockItemService.GetAllStockItems();
            return Ok(stockItems);
        }

        [HttpPut("{itemCode}")]
        public IActionResult UpdateStockItem(int itemCode, StockItem updatedStockItem)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return a bad request
                return BadRequest(ModelState);
            }

            // Filter and validate the updatedStockItem properties here


            stockItemService.UpdateStockItem(itemCode, updatedStockItem);
            var stockItems = stockItemService.GetAllStockItems();
            return Ok(stockItems);
        }

        [HttpDelete("{itemCode}")]
        public IActionResult DeleteStockItem(int itemCode)
        {
            stockItemService.DeleteStockItem(itemCode);
            var stockItems = stockItemService.GetAllStockItems();
            return Ok(stockItems);
        }
    }
}
