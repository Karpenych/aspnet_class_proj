using Microsoft.AspNetCore.Mvc;

namespace lr3.ViewComponent
{
    public class UserInfoViewComponent:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        bool   isAdmin;
        string login;

        public UserInfoViewComponent() //конструктор класс
        {
            login = System.Environment.UserName; 

            if (login == "admin") isAdmin = true;
            else isAdmin = false;
        }

        public IViewComponentResult Invoke()
        {
            var model = new UserModel()
            { 
                Login = login, 
                IsAdmin = isAdmin 
            };

            return View("UserInfo", model);
        }
    }

    public class UserModel
    {
        public string Login;
        public bool IsAdmin;

        public UserModel(string s1 = "", bool s2 = false)
        {
            Login = s1; 
            IsAdmin = s2;
        }
    }



}

