using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index(string? section) // Display the Admin page
        {
            ViewBag.Section = section;
            return View();
        }

        [HttpGet]
        public IActionResult Login() // Display the login form
        {
            return View();
        }
    }
}
