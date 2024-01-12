using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class InvestmentDashboard
    {
        [Key]
        public int InvestmentID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
