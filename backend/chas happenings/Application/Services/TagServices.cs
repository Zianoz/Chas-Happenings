using Application.DTOs.TagDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.DTOMappers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TagServices : ITagServices
    {
        private readonly ITagRepositories _repo;
        public TagServices(ITagRepositories repo)
        {
            _repo = repo;
        }


        public async Task<int> AddTagServiceAsync(CreateTagDTO tagDTO)
        {
            var tag = DTOTagMapper.CreateTagModelFromDTOs(tagDTO);
            var newTag = await _repo.AddTagRepoAsync(tag);
            if (newTag != null)
            {
                return newTag.Id;
            }
            throw new InvalidOperationException($"Failed to add tag to database, Tag id was {newTag.Id}");
        }

        public async Task<int> DeleteTagByIdServiceAsync(int TagId)
        {
            var tag = await _repo.GetTagByIdRepoAsync(TagId);
            if (tag == null)
            {
                throw new KeyNotFoundException($"Tag with id {TagId} not found.");
            }
            var result = await _repo.DeleteTagByIdRepoAsync(TagId);
            return result;
        }

        public async Task<List<Tag?>> GetAllTagsServiceAsync()
        {
            var tags = await _repo.GetAllTagsRepoAsync();
            var tagList = new List<Tag>();
            foreach (var t in tags)
            {
                if (t != null)
                {
                    tagList.Add(new Tag
                    {
                        Id = t.Id,
                        TagName = t.TagName
                    });
                }
            }
            return tagList;
        }

        public async Task<Tag?> GetTagByIdServiceAsync(int TagId)
        {
            var tag = await _repo.GetTagByIdRepoAsync(TagId);
            if (tag == null)
            {
                throw new KeyNotFoundException($"Tag with id {TagId} not found.");
            }
            return tag;
        }

        public async Task<int> UpdateTagServiceAsync(int TagId, UpdateTagDTO updateTagDTO)
        {
            var existingTag = await _repo.GetTagByIdRepoAsync(TagId);
            if (existingTag == null)
            {
                throw new KeyNotFoundException($"Tag with id {TagId} not found.");
            }
            // Map UpdateTagDTO to Tag
            existingTag.TagName = updateTagDTO.TagName;
            var result = await _repo.UpdateTagRepoAsync(existingTag);
            return result;
        }
    }
}
