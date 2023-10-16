using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr2.Pages
{
    public class ProverbsModel : PageModel
    {
        public string Message { get; set; }
        public string txtfile { get; set; }

        private readonly ILogger<ProverbsModel> logger;

        public ProverbsModel(ILogger<ProverbsModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
            string v = $"Index page visited at {DateTime.UtcNow.ToLongTimeString()}";
            Message = v;
            logger.LogInformation(Message);
        }

        public void OnPost(string zad)
        {
            try
            {
                StreamReader sr = new("wwwroot/assets/" + zad + ".txt");
                txtfile = sr.ReadToEnd();
            }
            catch
            {
                txtfile = "Такого файла нет";
            }
        }
    }
}
