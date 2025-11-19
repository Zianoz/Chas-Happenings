using Application.DTOs.UserDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Irepositories
{
    public interface IUserRepositories
    {
        // Standard CRUD Operationer
        Task<User?> GetUserByIdRepoAsync(int userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> DeleteUserByIdRepoAsync(int userId);
        Task<int> AddUserRepoAsync(User user);
        Task<int> UpdateUserRepoAsync(User user);

        // Admin Endpoints 
        Task<List<User?>> GetAllUsersRepoAsync();

        // Extra User Operations
        Task<IEnumerable<User>> SearchUserRepoAsync(string query);
        Task<User?> GetUserByUsernameRepoAsync(string username);

    }
}
