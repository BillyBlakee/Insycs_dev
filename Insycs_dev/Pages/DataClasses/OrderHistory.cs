using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class OrderHistory
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("FinancialInstrument")]
        public int InstrumentID { get; set; }
        public string OrderType { get; set; } // Buy, Sell
        public int Quantity { get; set; }
        public decimal PriceAtOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // Completed, Cancelled
    }
}
