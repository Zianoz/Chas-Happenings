using Application.DTOs.CommentDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Irepositories
{
    public interface ICommentRepository
    {
        Task<int> AddCommentAsync(Comment comment);
    }
}
