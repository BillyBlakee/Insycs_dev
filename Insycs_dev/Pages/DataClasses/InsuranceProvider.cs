using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class InsuranceProvider
    {
        [Key]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ContactInfo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
