using System.ComponentModel.DataAnnotations;

namespace Starman.Models
{
    public class StockItem
    {
        [Required]
        public int ItemCode { get; set; }
        public string Description { get; set; } = String.Empty;
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public string Location { get; set; } = String.Empty;
        [Required]
        public string Supplier { get; set; } = String.Empty;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    }
}
