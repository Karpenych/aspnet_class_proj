using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr2_entity.Pages
{
    public class UpdateClientModel : PageModel
    {
        public static string id = "";
        public static string name = "";
        public static string firm = "";
        public static string city = "";
        public static string phone = "";
        public static string result = "";


        public void OnGet()
        {
            if (Request.Query.Count >= 5) 
            {
                id = Request.Query["КодКлиента"];
                name = Request.Query["Фамилия"];
                firm = Request.Query["Фирма"];
                city = Request.Query["Город"];
                phone = Request.Query["Телефон"];
            }

            if (Request.Query.Count == 5)
            {
                result = "Получить запись: Успех.";
                return;
            }

            string op = Request.Query["operation_"] + "";
            int id_ = Convert.ToInt32(id);
            KdaMovementOfGoodsContext db = new();
            string res1 = "";

            if (op == "update")
            {
                Клиент? obj = db.Клиентs.FirstOrDefault(o => o.КодКлиента == id_);
                int num = 0;
                if (obj != null)
                {
                    obj.Фамилия = name;
                    obj.Фирма = firm;
                    obj.Город = city;
                    obj.Телефон = phone;
                    res1 = name + " " + firm + " " + city + " " + phone;
                    num = db.SaveChanges();
                }
                result = num == 1 ? "Обновление: Успех." : "Обновление: Не выполнено.";
                result += " res1=" + res1 + " (obj!=null) " + (obj != null).ToString();
                return;
            }

            if(op == "prev") {
                Клиент? obj = db.Клиентs.OrderBy(o => o.КодКлиента).LastOrDefault(o => o.КодКлиента < id_);
                if (obj != null)
                {
                    id = obj.КодКлиента.ToString();
                    name = obj.Фамилия;
                    firm = obj.Фирма;
                    city = obj.Город;
                    phone = obj.Телефон;
                    result = "Предыдущая запись: Успех.";
                    return;
                }
            }

            if (op == "next")
            {
                Клиент? obj = db.Клиентs.FirstOrDefault(o => o.КодКлиента > id_);
                if (obj != null)
                {
                    id = obj.КодКлиента.ToString();
                    name = obj.Фамилия;
                    firm = obj.Фирма;
                    city = obj.Город;
                    phone = obj.Телефон;
                    result = "Следующая запись: Успех.";
                    return;
                }
            }


        }
    }
}
