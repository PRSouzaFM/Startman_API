using Starman.Models;
using System;
using System.Collections.Generic;

namespace Starman.Interfaces
{
    public interface IStockItemService
    {
        StockItem GetStockItem(int itemCode);
        IEnumerable<StockItem> GetAllStockItems();
        void AddStockItem(StockItem stockItem);
        void UpdateStockItem(int itemCode, StockItem updatedStockItem);
        void DeleteStockItem(int itemCode);
    }
}
