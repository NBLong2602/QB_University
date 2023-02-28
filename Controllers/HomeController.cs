using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using QB_University.Models;
using QB_University.MyClass;
using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

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
            if(checkLogin()==true)
            {
                return View();
            }
            return View("Login");
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            DataTable dt = conDB.GetData($"SELECT * FROM user WHERE user = '{username}' AND pass = '{password}'");
            if(dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("login","1");
                return View("Index");
            }
            return View();
        }


        private bool checkLogin()
        {
            bool result = false;
            if (HttpContext.Session.GetString("login")!=null)
            {
                if (HttpContext.Session.GetString("login") != "1")
                {
                    result = true;
                }
            }
            return result;
        }
    }
}