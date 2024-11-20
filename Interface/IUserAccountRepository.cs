using System;
using CNCSapi.Dto;
using CNCSproject.Dto;
using CNCSproject.Models;

namespace CNCSproject.Interface;

public interface IUserAccountRepository
{
    Task<IEnumerable<UserAccountDto>> GetAllAsync(); //get all user account
    Task<UserAccountDto?> GetAsync(int id); //get single user account
    Task AddAsync(UserAccount userAccount); // Add new user account
    Task<bool> UpdateAsync(UserAccount userAccount); // Update existing user account
    Task<bool> DeleteAsync(int id); // Delete user account by ID
    Task<bool> SaveAllAsync(); // Save changes to the database
}
