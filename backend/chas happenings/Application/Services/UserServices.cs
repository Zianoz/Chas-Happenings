using Application.DTOs.UserDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.DTOMappers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepositories _userRepo;
        public UserServices(IUserRepositories userRepo)
        {
            _userRepo = userRepo;
        }

        //stand CRUD Operations
        public async Task<GetUserByIdDTO?> GetUserByIdServicesAsync(int userId)
        {
            var user = await _userRepo.GetUserByIdRepoAsync(userId);
            if (user == null)
            {
                return null;
            }
            var userDTO = DTOUserMapper.GetUserByIdMapper(user);
            return userDTO;
        }

        public async Task<bool> DeleteUserByIdServicesAsync(int userId)
        {
            var userDeleted = await _userRepo.DeleteUserByIdRepoAsync(userId);
            if (userDeleted != false)
            {
                return userDeleted;
            }
            else
            {
                throw new Exception("Failed to delete the user from the database.");
            }
        }
        public Task<int> AddUserServicesAsync(CreateUserDTO userDTO)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateUserServicesAsync(int userId, UpdateUserDTO updateUserDTO)
        {
            throw new NotImplementedException();
        }
        //extra user operations
        public async Task<GetUserAllDataDTO?> GetUserAllDataAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserCommentsDTO?> GetUserCommentsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        // for admin

        public async Task<List<GetUserByIdDTO?>> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsersRepoAsync();
            var userList = new List<GetUserByIdDTO>();
            foreach (var u in users)
            {
                if (u != null)
                {
                    userList.Add(DTOUserMapper.GetUserByIdMapper(u));
                }
            }
            return userList;
        }

        public Task<List<User?>> GetListOfUsers(List<int> userIds)
        {
            throw new NotImplementedException();
        }




    }
}
