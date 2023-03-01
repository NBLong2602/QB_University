using Microsoft.AspNetCore.Mvc;
using System.Data;
using QB_University.MyClass;

namespace QB_University.Controllers
{
    public class ManageController : Controller
    {
        private ConDB conDB = new ConDB();
        public IActionResult Student()
        {
            DataTable dt = conDB.GetData("SELECT * FROM member WHERE role = '1';") ;
            return View(dt);
        }

        public IActionResult Teacher()
        {
            DataTable dt = conDB.GetData("SELECT * FROM member WHERE role = '2';");
            return View(dt);
        }

    }
}
