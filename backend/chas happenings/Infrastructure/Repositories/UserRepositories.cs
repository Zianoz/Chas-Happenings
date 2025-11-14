using Application.Interfaces.Irepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly ChasHappeningsDbContext _context;

        public UserRepositories(ChasHappeningsDbContext context)
        {
            _context = context;
        }

        // Standard CRUD Operationer
        public async Task<User?> GetUserByIdRepoAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task<bool> DeleteUserByIdRepoAsync(int userId)
        {
            var results = await _context.Users.Where(u => u.Id == userId).ExecuteDeleteAsync();
            if (results > 0)
            {
                return true;
            }   
            return false;
        }
        public async Task<int> AddUserRepoAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> UpdateUserRepoAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user.Id;

        }

        // Admin Endpoints 
        public async Task<List<User?>> GetAllUsersRepoAsync()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }
    }
}
