using Microsoft.AspNetCore.Mvc;
using System.Data;
using QB_University.MyClass;
using PageList;
using QB_University.Models;

namespace QB_University.Controllers
{
    public class ManageController : Controller
    {
        private ConDB conDB = new ConDB();
        public IActionResult Student()
        {
            DataTable dt = conDB.GetData($"SELECT * FROM member WHERE role = '1' ORDER BY ID ASC;");
            return View(dt);
        }

        public IActionResult Teacher()
        {
            DataTable dt = conDB.GetData($"SELECT * FROM member WHERE role = '2' ORDER BY ID ASC;");
            return View(dt);
        }

        public IActionResult edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult edit(int ID, string fname, string Email, string Password, string Phone)
        {

            if (fname != "" || Email != "" || Password != "" || Phone != "")
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

        [HttpPost]
        public IActionResult add(int Role, string fname, string Email, string Password, string Phone)
        {
            if (fname == null || Email == null || Password == null || Phone == null || Role.ToString() == null)
            {
                return View();
            }
            else
            {
                conDB.ExecuteQuery($"INSERT INTO member (role,Full_name,Pass,Phone,Email) VALUES ('{Role}','{fname}','{Password}','{Phone}','{Email}')");
                if (Role == 1) return RedirectToAction("Student");
                else if (Role == 2) return RedirectToAction("Teacher");
                else return View();
            }
        }

        public IActionResult delete()
        {
            return RedirectToAction("About","Home");
        }

        [HttpGet]
        public IActionResult delete(int ID) {
            DataTable dt = conDB.GetData($"SELECT role FROM member WHERE ID = '{ID}'");
            string getRole = null;
            if(dt.Rows.Count > 0)
            {
                //Chạy vòng for lấy values trong cột
                foreach (DataRow dr in dt.Rows)
                {
                    getRole = dr["role"].ToString();
                    //Chỉ định dòng bao nhiêu trong cột sẽ được lấy giá trị
                    //getRole = dr.ItemArray[0].ToString();
                }
                conDB.ExecuteQuery($"DELETE FROM member WHERE ID = {ID}");
            }
            if (getRole == "1") return RedirectToAction("Student");
            else if (getRole == "2") return RedirectToAction("Teacher");
            else return RedirectToAction("delete");

        }

    }
}
