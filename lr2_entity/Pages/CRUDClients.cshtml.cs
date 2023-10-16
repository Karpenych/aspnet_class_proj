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
            ������? obj = new();

            if (Request.Query.Count == 4)
            {
                obj.������� = Request.Query["_name"];
                obj.����� = Request.Query["_firm"];
                obj.����� = Request.Query["_city"];
                obj.������� = Request.Query["_phone"];
                db.������s.Add(obj);
                num = db.SaveChanges();
                result = num == 1 ? "����������: �����." : "����������: �� ���������.";
                UpdateClientModel.result = result;
                return;
            }

            if (Request.Query.Count == 1)
            {
                var id_ = Convert.ToInt32(Request.Query["����������"]);
                obj = db.������s.Find(id_);
                if (obj != null) db.������s.Remove(obj);
                num = db.SaveChanges();
                result = num == 1 ? "��������: �����." : "��������: �� ���������";
                UpdateClientModel.result = result;
                return;
            }
        }
    }
}
