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
                id = Request.Query["����������"];
                name = Request.Query["�������"];
                firm = Request.Query["�����"];
                city = Request.Query["�����"];
                phone = Request.Query["�������"];
            }

            if (Request.Query.Count == 5)
            {
                result = "�������� ������: �����.";
                return;
            }

            string op = Request.Query["operation_"] + "";
            int id_ = Convert.ToInt32(id);
            KdaMovementOfGoodsContext db = new();
            string res1 = "";

            if (op == "update")
            {
                ������? obj = db.������s.FirstOrDefault(o => o.���������� == id_);
                int num = 0;
                if (obj != null)
                {
                    obj.������� = name;
                    obj.����� = firm;
                    obj.����� = city;
                    obj.������� = phone;
                    res1 = name + " " + firm + " " + city + " " + phone;
                    num = db.SaveChanges();
                }
                result = num == 1 ? "����������: �����." : "����������: �� ���������.";
                result += " res1=" + res1 + " (obj!=null) " + (obj != null).ToString();
                return;
            }

            if(op == "prev") {
                ������? obj = db.������s.OrderBy(o => o.����������).LastOrDefault(o => o.���������� < id_);
                if (obj != null)
                {
                    id = obj.����������.ToString();
                    name = obj.�������;
                    firm = obj.�����;
                    city = obj.�����;
                    phone = obj.�������;
                    result = "���������� ������: �����.";
                    return;
                }
            }

            if (op == "next")
            {
                ������? obj = db.������s.FirstOrDefault(o => o.���������� > id_);
                if (obj != null)
                {
                    id = obj.����������.ToString();
                    name = obj.�������;
                    firm = obj.�����;
                    city = obj.�����;
                    phone = obj.�������;
                    result = "��������� ������: �����.";
                    return;
                }
            }


        }
    }
}
