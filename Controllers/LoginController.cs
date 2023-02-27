using Microsoft.AspNetCore.Mvc;

namespace QB_University.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
    }
}
