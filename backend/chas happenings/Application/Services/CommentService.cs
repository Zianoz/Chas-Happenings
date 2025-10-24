using Application.DTOs.CommentDTO;
using Application.DTOs.CommentDTOs;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<int> AddCommentAsync(CreateCommentDTO commentDTO)
        {
            var comment = DTOCommentMapper.CreateCommentMapper(commentDTO);
            var response = await _commentRepository.AddCommentAsync(comment);
            if (response > 0)
            {
                return response;
            }
            else
            {
                throw new InvalidOperationException("Failed to add comment to the database.");
            }
        }

        public async Task<IEnumerable<GetCommentsByEventIdDTO>> GetCommentsByEventId(int eventId)
        {
            var eventComments = await _commentRepository.GetCommentsByEventIdAsync(eventId);
            var eventCommentsDTO = DTOCommentMapper.GetCommentsMapper(eventComments);
            return eventCommentsDTO;

        }

        public async Task<int> EditCommentById(int commentId, PutCommentDTO dto)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (comment == null)
            {
                throw new Exception($"Comment with ID {commentId} not found.");
            }
            
            comment.Text = dto.Text;

            var result = await _commentRepository.SaveCommentChangesByIdAsync(comment);
            if (result <= 0)
            {
                throw new InvalidOperationException("Failed to save changes to the comment.");
            }

            return result;
        }

        public async Task<int> DeleteCommentByIdAsync(int commentId)
        {
            var comment = await _commentRepository.DeleteCommentByIdAsync(commentId);
            if (comment > 0)
            {
                return comment;
            }
            else
            {
                throw new Exception("Failed to delete the comment from the database.");
            }

        }
    }
}
