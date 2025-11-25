using Application.DTOs.UserDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.DTOMappers;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepositories _userRepo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public UserServices(IUserRepositories userRepo, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        //stand CRUD Operations
        public async Task<string> LoginUserServiceAsync(LoginUserDTO dto)
        {
            var user = await _userRepo.GetUserByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new InvalidCredentialException("Invalid Email or password.");
            }
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialException("Invalid Email or password.");
            }
            return await _jwtService.GenerateToken(user);
        }
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
        public async Task<int> AddUserServicesAsync(CreateUserDTO userDTO)
        {
            var user = DTOUserMapper.CreateUserByDTOMapper(userDTO);

            //ASP.NET Identity built in password hasher, send in user and plain password, get back hashed password
            user.PasswordHash = _passwordHasher.HashPassword(user, userDTO.Password);

            return await _userRepo.AddUserRepoAsync(user);
        }
        public async Task<int> UpdateUserServicesAsync(int userId, UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepo.GetUserByIdRepoAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with id {userId} not found.");
            }
            var updatedUser = DTOUserMapper.UpdateUserByDTOMapper(user, updateUserDTO);
            return await _userRepo.UpdateUserRepoAsync(updatedUser);
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

        public async Task<IEnumerable<User>> SearchUserAsync(string query)
        {
            return await _userRepo.SearchUserRepoAsync(query);
        }

        public async Task<GetUserByIdDTO?> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepo.GetUserByUsernameRepoAsync(username);
            if (user == null)
            {
                throw new Exception($"User with id {username} not found.");
            }
            var userDTO = DTOUserMapper.GetUserByIdMapper(user);
            return userDTO;
        }
    }
}
