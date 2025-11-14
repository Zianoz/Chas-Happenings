using Application.DTOs.EvenDTOs;
using Application.DTOs.UserDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IUserService
    {
        //stand CRUD Operations
        Task<string> LoginUserServiceAsync(LoginUserDTO dto);
        Task<GetUserByIdDTO?> GetUserByIdServicesAsync(int userId); //Jing
        Task<bool> DeleteUserByIdServicesAsync(int userId);//Jing
        Task<int> AddUserServicesAsync(CreateUserDTO userDTO);//Zian
        Task<int> UpdateUserServicesAsync(int userId, UpdateUserDTO updateUserDTO);//Zian

        //extra user operations
        Task<GetUserAllDataDTO?> GetUserAllDataAsync(int userId);// includes events created, comments, attending, interested
        Task<GetUserCommentsDTO?> GetUserCommentsAsync(int userId);

        // for admin
        Task<List<GetUserByIdDTO?>> GetAllUsers();//Jing
        Task<List<User?>> GetListOfUsers(List<int>userIds);//Zian
    }
}
