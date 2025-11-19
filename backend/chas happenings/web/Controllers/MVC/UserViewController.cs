using Application.DTOs.UserDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Services; // wherever IUserService is
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chas_happenings.Controllers.MVC
{
    public class UserViewController : Controller
    {
        private readonly IUserService _userService;

        public UserViewController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            // Clear success message when just opening the form normally
            if (TempData["Success"] != null && !Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                TempData.Remove("Success");
            }

            return View(new CreateUserDTO());
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
            return RedirectToAction("Index", "Admin", new { section = "user-management" });
        }


        // GET: /UserView/SelectUserToDelete
        [HttpGet]
        public IActionResult SelectUserToDelete()
        {
            return View(); // A simple form where admin enters userId or username
        }

        // GET: /UserView/DeleteUser
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int? id, string? username)
        {
            if (!id.HasValue && string.IsNullOrEmpty(username))
            {
                TempData["ErrorMessage"] = "Please enter a user id or username.";
                return RedirectToAction("SelectUserToDelete");
            }

            var user = id.HasValue
                ? await _userService.GetUserByIdServicesAsync(id.Value)
                : await _userService.GetUserByUsernameAsync(username);

            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("SelectUserToDelete");
            }

            var dto = new UpdateUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Course = user.Course,
                Role = user.Role,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserDescription = user.UserDescription
            };

            return View("DeleteUserConfirmation", dto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(int id)
        {
            var success = await _userService.DeleteUserByIdServicesAsync(id);

            if (success)
            {
                TempData["Success"] = "User deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete user.";
            }

            return RedirectToAction("Index", "Admin", new { section = "user-management" });
        }



        // GET: /UserView/SelectUserToEdit
        [HttpGet]
        public IActionResult SelectUserToEdit()
        {
            return View(); // A simple form where admin enters userId or username
        }


        // GET: /UserView/EditUser/5

        [HttpGet]
        public async Task<IActionResult> EditUser(int? id, string? username)   
        {
            if (!id.HasValue && string.IsNullOrEmpty(username))
            {
                TempData["ErrorMessage"] = "Please enter a user id or username.";
                return RedirectToAction("SelectUserToEdit");
            }

            var user = id.HasValue
                ? await _userService.GetUserByIdServicesAsync(id.Value)
                : await _userService.GetUserByUsernameAsync(username);

            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("SelectUserToEdit");
            }

            var dto = new UpdateUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Course = user.Course,
                Role = user.Role,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserDescription = user.UserDescription
            };

            return View(dto);
        }


        // POST: /UserView/EditUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, UpdateUserDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _userService.UpdateUserServicesAsync(id, dto);

            if (result > 0)
            {
                TempData["Success"] = "User updated successfully!";
                return RedirectToAction("Index", "Admin", new { section = "user-management" });
            }

            TempData["Error"] = "Failed to update user.";
            return View(dto); //this might be problematic
        }


        public async Task<IActionResult> Search(string query)
        {
            var users = await _userService.SearchUserAsync(query);
            ViewBag.Section = "user-management";
            return View("~/Views/Admin/Index.cshtml", users);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users == null || !users.Any())
            {
                TempData["ErrorMessage"] = "No users found.";
                return View(new List<GetUserByIdDTO>()); // return empty list to view
            }

            return View(users);
        }


    }
}
