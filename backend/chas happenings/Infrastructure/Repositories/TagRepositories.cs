using Application.Interfaces.Irepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class TagRepositories : ITagRepositories
    {
        private readonly ChasHappeningsDbContext _context;

        public TagRepositories(ChasHappeningsDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddTagRepoAsync(Tag tag)
        {
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<int> DeleteTagByIdRepoAsync(int tagId)
        {
            var results = await _context.Tags
                .Where(t => t.Id == tagId)
                .ExecuteDeleteAsync();
            return results;
        }

        public async Task<List<Tag?>> GetAllTagsRepoAsync()
        {
            var allTags =  await _context.Tags.ToListAsync();
            return allTags;
        }

        public async Task<Tag?> GetTagByIdRepoAsync(int TagId)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == TagId);
            return tag;
        }

        public async Task<int> UpdateTagRepoAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            var results = await _context.SaveChangesAsync();
            return results;
        }
    }
}
