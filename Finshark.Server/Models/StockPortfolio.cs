using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Models
{
    [Table("StockPortfolio")]
    public class StockPortfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}
