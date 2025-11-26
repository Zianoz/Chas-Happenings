using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers.MVC
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
