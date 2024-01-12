using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class Holding
    {
        [Key]
        public int HoldingID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("FinancialInstrument")]
        public int InstrumentID { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CurrentValue { get; set; }
        public DateTime DateAcquired { get; set; }
    }
}
