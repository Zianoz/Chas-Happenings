using Application.DTOs.UserDTOs;
using Application.Interfaces.IServices;
using Application.Services; // wherever IUserService is
using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers.MVC
{
    public class UserViewController : Controller
    {
        private readonly IUserService _userService;

        public UserViewController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /User/CreateUser
        [HttpGet]
        public IActionResult CreateUser()
        {
            //return View(new CreateUserDTO());
            return View();
        }

        // POST: /User/CreateUser
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            var userId = await _userService.AddUserServicesAsync(dto);

            if (userId == 0)
            {
                TempData["Error"] = "Failed to create user";
                return View(dto);
            }

            TempData["Success"] = "User created successfully!";
            return RedirectToAction("CreateUser");
        }
    }
}
