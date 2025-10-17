using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
