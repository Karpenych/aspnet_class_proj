using Microsoft.AspNetCore.Mvc;

namespace lr4.Controllers
{
    public class InfoCheckController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // отображение формы для ввода данных
        }

        [HttpPost]
        public IActionResult Create(lr4.Models.UserInfo person)
        {
            if (ModelState.IsValid) // обработка данных
                return Content($"{person.Name} - {person.Email} – {person.Phone}");
            else 
                return View(person);
        }
    }
}
