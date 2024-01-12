using Insycs_dev.Pages.DataClasses;
using Insycs_dev.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Insycs_dev.Pages
{
    public class IndexModel : PageModel
    {
        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = DBClass.GetAllUsers(); // Implement this method in DBClass
        }
    }
}