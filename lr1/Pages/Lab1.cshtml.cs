using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr1.Pages
{
    public class Lab1Model : PageModel
    {
        public void OnGet()
        {
            Statics.msg = "Aboba";
        }
    }
}
