using Application.DTOs.CommentDTO;
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
    }
}
