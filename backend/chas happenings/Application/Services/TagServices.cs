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
    internal class TagServices : ITagServices
    {
        private readonly ITagRepositories _repo;
        public TagServices(ITagRepositories repo)
        {
            _repo = repo;
        }


        public Task<int> AddTagServiceAsync(CreateTagDTO tagDTO)
        {
            var newTag = DTOTagMapper.CreateTagModelFromDTOs(tagDTO);

        }

        public Task<int> DeleteTagByIdServiceAsync(int TagId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag?>> GetAllTagsServiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag?> GetTagByIdServiceAsync(int TagId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTagServiceAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
