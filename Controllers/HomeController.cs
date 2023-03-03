using Microsoft.AspNetCore.Mvc;
using QB_University.Models;
using QB_University.MyClass;
using System.Data;
using System.Diagnostics;

namespace QB_University.Controllers
{
    public class HomeController : Controller
    {   
        private ConDB conDB = new ConDB();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            if (checkLogin() == true)
            {
                return View();
            }
            else return RedirectToAction("Login");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            DataTable dt = conDB.GetData($"SELECT * FROM user WHERE user = '{username}' AND pass = '{password}'");
            if(dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("login","1");
                return RedirectToAction("Index");
            }
            return View();
        }


        private bool checkLogin()
        {
            bool result = false;
            if (HttpContext.Session.GetString("login")!=null)
            {
                if (HttpContext.Session.GetString("login") == "1")
                {
                    result = true;
                }
            }
            return result;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RoleProvider()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleProvider(string Quyen1, string Quyen2, string Quyen3, int ID)
        {
            string success = "Cập Nhật Thành Công";
            string faultID = "ID không tồn tại";
            string nullID = "Chưa nhập ID";
            if(ID != 0)
            {
                DataTable dt = conDB.GetData($"SELECT * FROM member WHERE ID = '{ID}'");
                if (dt.Rows.Count > 0)
                {
                    conDB.ExecuteQuery($"UPDATE member SET Quyen1 = '{Quyen1}', Quyen2 = '{Quyen2}', Quyen3 = '{Quyen3}' WHERE ID = '{ID}'");
                    ViewBag.rs = success;
                    //return RedirectToAction("Index");
                }
                ViewBag.rs = faultID;
            }
            ViewBag.rs = nullID;
            return RedirectToAction("RoleProvider");
        }
    }
}