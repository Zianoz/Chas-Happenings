using Application.DTOs.CommentDTO;
using Application.DTOs.CommentDTOs;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Irepositories
{
    public interface ICommentRepository
    {
        Task<int> AddCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByEventIdAsync(int eventId);
        Task<Comment> GetCommentByIdAsync(int commentId); 
        Task<int> SaveCommentChangesByIdAsync(Comment comment);
        Task<int> DeleteCommentByIdAsync(int commentId);
    }
}
