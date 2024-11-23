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
        .Where(user => user.IsDeleted == false)
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

    public async Task<bool> AddAsync(UserAccount userAccount)
    {
        await context.tblUserAccount.AddAsync(userAccount);
        return await  SaveAllAsync();
    }

     public async Task<bool> UpdateAsync(UserAccount userAccount)
    {
        context.tblUserAccount.Update(userAccount);
        return await SaveAllAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await context.tblUserAccount
            .Where(a => a.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));

        return deleted > 0;
    }

    public async Task<bool> IsUserExistsAsync(string Username)
    {
        return await context.tblUserAccount
            .AnyAsync(x => x.Username.ToLower() == Username.ToLower() && x.IsDeleted == false);
    }


    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
