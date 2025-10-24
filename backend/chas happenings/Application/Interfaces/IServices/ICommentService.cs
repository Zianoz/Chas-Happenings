using Application.DTOs.CommentDTO;
using Application.DTOs.CommentDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ICommentService
    {
        Task<int> AddCommentAsync(CreateCommentDTO commentDTO);
        Task<IEnumerable<GetCommentsByEventIdDTO>> GetCommentsByEventId(int eventId);
        Task<PutCommentDTO> EditCommentById(int commentId);
    }
}
