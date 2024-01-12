using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddPropertyModel : PageModel
{
    [BindProperty]
    public PropertyInputModel Property { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Here you would call your DBClass method to add the property
        // new DBClass("YourConnectionString").AddProperty(Property.UserId, Property.PropertyType, Property.PropertyValue, Property.Location, Property.PurchaseDate);

        return RedirectToPage("/Index"); // Redirect to a success page or another relevant page
    }

    public class PropertyInputModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PropertyValue { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
    }
}

