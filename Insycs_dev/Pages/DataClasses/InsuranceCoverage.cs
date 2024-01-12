using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class InsuranceCoverage
    {
        [Key]
        public int CoverageID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        public decimal TotalCoverage { get; set; } // Assets + Excess
        [ForeignKey("InsuranceProvider")]
        public int ProviderID { get; set; }
        public string CoverageDetails { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
