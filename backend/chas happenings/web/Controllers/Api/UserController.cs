using Application.DTOs.UserDTOs;
using Application.Interfaces.IServices;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /api/User/test (for browser testing)
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API is running correctly!");
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUserAsync(CreateUserDTO userDTO)
        {
            var userId = await _userService.AddUserServicesAsync(userDTO);
            if (userId == 0 || userId == null)
            {
                return BadRequest("Operation failed, could not create or save user");
            }
            return Created(string.Empty, userId);
        }

        [HttpPut("UpdateUserById/{userId}")]
        public async Task<ActionResult<int>> UpdateUserById(int userId, UpdateUserDTO updateUserDTO)
        {
            var updatedUserId = await _userService.UpdateUserServicesAsync(userId, updateUserDTO);
            if (updatedUserId <= 0)
            {
                return NotFound($"User with id {userId} not found.");
            }
            return Ok($"User with id {userId} updated successfully.");
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdServicesAsync(userId);
            if (user == null)
            {
                return NotFound($"User with id {userId} not found.");
            }
            return Ok(user);
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<ActionResult> DeleteUserById(int userId)
        {
            var result = await _userService.DeleteUserByIdServicesAsync(userId);
            if (result == false)
            {
                return NotFound($"Tag with id {userId} not found.");
            }
            return Ok($"User with id {userId} deleted successfully.");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var userList = await _userService.GetAllUsers();
            return Ok(userList);
        }
    }
}
