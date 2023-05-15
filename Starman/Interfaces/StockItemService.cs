using Starman.Data;
using Starman.Interfaces;
using Starman.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Starman.Services
{
    public class StockItemService : IStockItemService
    {
        private readonly StockItemDbContext dbContext;

        public StockItemService(StockItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StockItem GetStockItem(int itemCode)
        {
            return dbContext.StockItems.FirstOrDefault(item => item.ItemCode == itemCode);
        }

        public IEnumerable<StockItem> GetAllStockItems()
        {
            return dbContext.StockItems.ToList();
        }

        public void AddStockItem(StockItem stockItem)
        {
            stockItem.LastUpdated = DateTime.Now;
            dbContext.StockItems.Add(stockItem);
            dbContext.SaveChanges();
        }

        public void UpdateStockItem(int itemCode, StockItem updatedStockItem)
        {
            StockItem existingStockItem = dbContext.StockItems.FirstOrDefault(item => item.ItemCode == itemCode);
            if (existingStockItem != null)
            {
                existingStockItem.Description = updatedStockItem.Description;
                existingStockItem.UnitPrice = updatedStockItem.UnitPrice;
                existingStockItem.QuantityInStock = updatedStockItem.QuantityInStock;
                existingStockItem.Location = updatedStockItem.Location;
                existingStockItem.Supplier = updatedStockItem.Supplier;
                existingStockItem.LastUpdated = DateTime.Now;
                dbContext.SaveChanges();
            }
        }

        public void DeleteStockItem(int itemCode)
        {
            StockItem stockItem = dbContext.StockItems.FirstOrDefault(item => item.ItemCode == itemCode);
            if (stockItem != null)
            {
                dbContext.StockItems.Remove(stockItem);
                dbContext.SaveChanges();
            }
        }
    }
}
