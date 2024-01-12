using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insycs_dev.Pages.DataClasses
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public string PropertyType { get; set; } // e.g., home, boat
        public decimal PropertyValue { get; set; }
        public string Location { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
