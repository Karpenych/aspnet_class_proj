using Microsoft.AspNetCore.Mvc;

namespace lr3.Controllers
{
    public class PartialController : Controller
    {
        public static string?   Method {  get; set; }
        public static int       ParamAmount { get; set; }
        public static string?   Param1 { get; set; }
        public static string?   Param2 { get; set; }

        static public string? UserStyle { get; set; }


        [Route("Demo")]
        public IActionResult DemoExamples()
        {
            if (HttpContext.Request.Query.Count > 0)
                UserStyle = HttpContext.Request.Query["su"];
         
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Partial2()
        {    
            
            Method = HttpContext.Request.Method;
            ParamAmount = HttpContext.Request.Query.Count;
            Param1 = HttpContext.Request.Query["param1"];
            Param2 = HttpContext.Request.Query["param2"];
            return View("DemoExamples");
        }

    }
}
