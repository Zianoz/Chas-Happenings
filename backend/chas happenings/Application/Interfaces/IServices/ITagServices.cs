using Application.DTOs.TagDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ITagServices
    {
        // Standard CRUD Operationer
        Task<Tag?> GetTagByIdServiceAsync(int TagId);
        Task<int> DeleteTagByIdServiceAsync(int TagId);
        Task<int> AddTagServiceAsync(CreateTagDTO tagDTO);
        Task<int> UpdateTagServiceAsync(Tag tag);
        // Admin Endpoints 
        Task<List<Tag?>> GetAllTagsServiceAsync();
    }
}
