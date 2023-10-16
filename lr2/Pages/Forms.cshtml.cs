using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr2.Pages
{
    public class FormsModel : PageModel
    {
        public string txtfile { get; set; }
        public string path { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string Poet)
        {
            try
            {
                StreamReader sr = new("wwwroot/assets/poet/" + Poet + ".txt");
                txtfile = sr.ReadToEnd(); 
            }
            catch 
            {
                txtfile = "Такого файла нет";
            }
            
            try
            {
                path = "images/poet/" + Poet + ".jpg";
            }
            catch
            {
                path = "images/logo.jpg";
            }
        }
    }
}
