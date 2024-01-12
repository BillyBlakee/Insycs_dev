using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class BankDetail
    {
        [Key]
        public int BankDetailsID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
    }
}
