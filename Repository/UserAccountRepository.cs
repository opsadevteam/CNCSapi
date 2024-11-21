using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CNCSapi.Dto;
using CNCSproject.Dto;
using CNCSproject.Interface;
using CNCSproject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CNCSproject.Repository;

public class UserAccountRepository(CncssystemContext context, IMapper mapper) : IUserAccountRepository
{
    public async Task<IEnumerable<UserAccountDto>> GetAllAsync()
    {
        return await context.tblUserAccount
        .ProjectTo<UserAccountDto>(mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<UserAccountDto?> GetAsync(int id)
    {
        return await context.tblUserAccount
        .Where(a => a.Id == id)
        .ProjectTo<UserAccountDto>(mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }

    public async Task AddAsync(UserAccount userAccount)
    {
        await context.tblUserAccount.AddAsync(userAccount);
    }

     public async Task<bool> UpdateAsync(UserAccount userAccount)
        {
            var user = await context.tblUserAccount.FindAsync(userAccount.Id);
            
            if (user is null) return false;

            user.FullName = userAccount.FullName;
            user.Username = userAccount.Username;
            user.Password = userAccount.Password;
            user.UserGroup = userAccount.UserGroup;
            user.Status = userAccount.Status;
            user.DateAdded = userAccount.DateAdded;

            context.Entry(user).State = EntityState.Modified;

            return true;
        }

    public async Task<bool> DeleteAsync(int id)
    {
        var userAccount = await context.tblUserAccount.FindAsync(id);
        
        if (userAccount is null) return false;

        context.tblUserAccount.Remove(userAccount);

        return true;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
