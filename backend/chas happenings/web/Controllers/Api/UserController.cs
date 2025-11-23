using Application.DTOs.UserDTOs;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace chas_happenings.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUserAsync(LoginUserDTO dto)
        {
            try
            {
                var token = await _userService.LoginUserServiceAsync(dto);
                
                // Set HTTP-only cookie for security
                Response.Cookies.Append("authToken", token, new CookieOptions
                {
                    HttpOnly = true,  // Prevents JavaScript access (XSS protection)
                    Secure = true,    // Only sent over HTTPS
                    SameSite = SameSiteMode.None, // Works for same-site (localhost to localhost)
                    Expires = DateTimeOffset.UtcNow.AddDays(7) // Token expiry
                });
                
                return Ok(new { Token = token, Message = "Login successful" });
            }
            catch (InvalidCredentialException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception)
            {
                // Log it (e.g. using ILogger)
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [Authorize]
        [HttpGet("Authenticate")] //Endpoint to (deconstruct) the token for frontend validation
        public async Task<ActionResult> Authenticate()
        {
            var identity = HttpContext.User;

            var role = identity.FindFirst(ClaimTypes.Role)?.Value;
            var email = identity.FindFirst(ClaimTypes.Email)?.Value;
            var id = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new { id, email, role });
        }

        [HttpPost("Logout")]
        public async Task<ActionResult> Logout()
        {
            // Delete the JWT token cookie
            Response.Cookies.Delete("authToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            });
            
            return Ok(new { message = "Logged out successfully" });
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
        public async Task<ActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdServicesAsync(userId);
            if (user == null)
            {
                return NotFound($"User with id {userId} not found.");
            }
            return Ok(user);
        }

        [HttpDelete("Delete/{userId}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var userList = await _userService.GetAllUsers();
            return Ok(userList);
        }
    }
}
