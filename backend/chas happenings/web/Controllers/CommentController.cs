using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.IServices;
using Application.DTOs.CommentDTO;
using Domain.Models;
using Application.DTOs.CommentDTOs;

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

            return Created(string.Empty, result);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<IEnumerable<GetCommentsByEventIdDTO>>> GetCommentsByEventId(int eventId)
        {
            var comments = await _commentService.GetCommentsByEventId(eventId);

            if (comments == null || !comments.Any())
                return NotFound($"No comments found for event with ID {eventId}.");

            return Ok(comments);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<PutCommentDTO>> EditCommentById(int commentId)
        {
            var comment = await _commentService.EditCommentById(commentId);
            return Ok(comment);
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult<int>> DeleteCommentByIdAsync(int commentId)
        {
            var result = await _commentService.DeleteCommentByIdAsync(commentId);
            if (result == null)
            {
                throw new Exception("Comment not found");
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
