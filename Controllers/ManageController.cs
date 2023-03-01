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
            DataTable dt = conDB.GetData("SELECT * FROM course;");
            return View(dt);
        }

        public IActionResult Teacher()
        {
            return View();
        }

    }
}
