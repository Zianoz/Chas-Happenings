using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Irepositories
{
    internal interface ITagRepositories
    {
        // Standard CRUD Operationer

        Task<Tag?> GetTagByIdRepoAsync(int TagId);
        Task<int> DeleteTagByIdRepoAsync(int TagId);
        Task<int> AddTagRepoAsync(Tag tag);
        Task<int> UpdateTagRepoAsync(Tag tag);

        // Admin Endpoints 
        Task<List<Tag?>> GetAllTagsRepoAsync();

    }
}
