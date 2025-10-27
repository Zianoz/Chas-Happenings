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
        Task<bool> DeleteUserByIdRepoAsync(int userId);
        Task<User> AddUserRepoAsync(User user);
        Task<int> UpdateUserRepoAsync(User user);

        // Admin Endpoints 
        Task<List<User?>> GetAllUsersRepoAsync();

    }
}
