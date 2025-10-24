using Application.DTOs.CommentDTO;
using Application.DTOs.CommentDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ChasHappeningsDbContext _context;

        public CommentRepository(ChasHappeningsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByEventIdAsync(int eventId)
        {
            var eventComments = _context.Comments
                .Where(c => c.EventId == eventId)
                .Include(c => c.Author)
                .ToListAsync();
            return await eventComments;
        }
        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(c => c.Id == commentId);
            return comment;
        }
        public async Task<int> SaveCommentChangesByIdAsync(Comment comment)
        {
            await _context.SaveChangesAsync();
            return comment.Id;
        }
        public async Task<int> DeleteCommentByIdAsync(int commentId)
        {
            var result = await _context.Comments
                .Where(c => c.Id == commentId)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
