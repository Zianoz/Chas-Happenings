using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.IServices;
using Application.DTOs.CommentDTO;

namespace chas_happenings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddComment(CreateCommentDTO commentDTO)
        {
            var result = await _commentService.AddCommentAsync(commentDTO);

            return Ok("Comment added successfully");
        }
    }
}
