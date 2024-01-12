using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class FinancialInstrument
    {
        [Key]
        public int InstrumentID { get; set; }
        public string Name { get; set; } // e.g., stock name, bond name
        public string Type { get; set; } // Stock, Bond, ETF, etc.
        public string TickerSymbol { get; set; }
        public decimal MarketPrice { get; set; }
        public string HistoricalData { get; set; }
    }
}
