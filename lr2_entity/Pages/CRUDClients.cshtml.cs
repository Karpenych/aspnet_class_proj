using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lr2_entity.Pages
{
    public class CRUDModel : PageModel
    {
        string result = "";
        int num = 0;

        public void OnGet()
        {
            KdaMovementOfGoodsContext db = new();
            Клиент? obj = new();

            if (Request.Query.Count == 4)
            {
                obj.Фамилия = Request.Query["_name"];
                obj.Фирма = Request.Query["_firm"];
                obj.Город = Request.Query["_city"];
                obj.Телефон = Request.Query["_phone"];
                db.Клиентs.Add(obj);
                num = db.SaveChanges();
                result = num == 1 ? "Добавление: Успех." : "Добавление: Не выполнено.";
                UpdateClientModel.result = result;
                return;
            }

            if (Request.Query.Count == 1)
            {
                var id_ = Convert.ToInt32(Request.Query["КодКлиента"]);
                obj = db.Клиентs.Find(id_);
                if (obj != null) db.Клиентs.Remove(obj);
                num = db.SaveChanges();
                result = num == 1 ? "Удаление: Успех." : "Удаление: Не выполнено";
                UpdateClientModel.result = result;
                return;
            }
        }
    }
}
