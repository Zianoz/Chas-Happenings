using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.IServices;
using Application.DTOs.TagDTOs;
using Domain.Models;

namespace chas_happenings.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagServices _tagServices;

        public TagController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateTag(CreateTagDTO createTagDTO)
        {
            var tagId = await _tagServices.AddTagServiceAsync(createTagDTO);
            if (tagId == 0 || tagId == null)
            {
                return BadRequest("Operation failed, could not create or save tag");
            }
            return Ok(tagId);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Tag>>> GetAllTags()
        {
            var tagList = await _tagServices.GetAllTagsServiceAsync();
            return Ok(tagList);
        }

        [HttpGet("GetTagById/{tagId}")]
        public async Task<ActionResult<Tag>> GetTagById(int tagId)
        {
            var tag = await _tagServices.GetTagByIdServiceAsync(tagId);
            if (tag == null)
            {
                return NotFound($"Tag with id {tagId} not found.");
            }
            return Ok(tag);
        }

        [HttpDelete("Delete/{tagId}")]
        public async Task<ActionResult> DeleteTag(int tagId)
        {
            var result = await _tagServices.DeleteTagByIdServiceAsync(tagId);
            if (result == 0)
            {
                return NotFound($"Tag with id {tagId} not found.");
            }
            return Ok($"Tag with id {tagId} deleted successfully.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateTag(int TagId, UpdateTagDTO updateTagDTO)
        {
            var result = await _tagServices.UpdateTagServiceAsync(TagId, updateTagDTO);
            if (result == 0)
            {
                return BadRequest("Operation failed, could not update tag");
            }
            return Ok("Tag updated successfully.");
        }
    }
}