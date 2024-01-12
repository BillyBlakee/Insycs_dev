using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("BankDetail")]
        public int BankDetailsID { get; set; }
        public string Status { get; set; } // e.g., pending, completed
        public DateTime CreatedAt { get; set; }
    }
}
