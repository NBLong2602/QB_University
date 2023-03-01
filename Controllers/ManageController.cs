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
            
            DataTable dt = conDB.GetData($"SELECT * FROM member WHERE role = '1';");
            return View(dt);
        }

        public IActionResult Teacher()
        {
            DataTable dt = conDB.GetData($"SELECT * FROM member WHERE role = '2';");
            return View(dt);
        }

        public IActionResult edit() {
            return View();
        }

        [HttpPost]
        public IActionResult edit(int ID, string fname, string Email, string Password, string Phone)
        {
            
            if (fname != ""|| Email != ""|| Password != ""|| Phone != "")
            {
                if (fname != null)
                {
                    conDB.ExecuteQuery($"UPDATE member SET full_name = '{fname}' WHERE ID = '{ID}'");
                }
                if (Email != null)
                {
                    conDB.ExecuteQuery($"UPDATE member SET Email = '{Email}' WHERE ID = '{ID}'");
                }
                if (Password != null)
                {
                    conDB.ExecuteQuery($"UPDATE member SET Pass = '{Password}' WHERE ID = '{ID}'");
                }
                if (Phone != null)
                {
                    conDB.ExecuteQuery($"UPDATE member SET Phone = '{Phone}' WHERE ID = '{ID}'");
                }
                DataTable dt = conDB.GetData($"SELECT * FROM member WHERE ID = '{ID}' AND role = '1'");
                if (dt.Rows.Count > 0)
                {
                    return RedirectToAction("Student");
                }
                else return RedirectToAction("Teacher");
            }
            else return View();

        }


        public IActionResult add()
        {
            return View();
        }

    }
}
