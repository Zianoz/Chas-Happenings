using Application.DTOs.CommentDTO;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.CommentMappers;
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
            var comment = CommentMapper.CreateCommentMapper(commentDTO);
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
    }
}
