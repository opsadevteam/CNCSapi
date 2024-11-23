using AutoMapper;
using CNCSapi.Dto;
using CNCSproject.Dto;
using CNCSproject.Interface;
using CNCSproject.Models;
using CNCSproject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSproject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController(IUserAccountRepository _userAccountRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAccountDto>>> GetUserAccountsAsync()
    {
        var users = await _userAccountRepository.GetAllAsync();

        return users.Any() ?
            Ok(users) :
            NotFound("No user accounts found.");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserAccountDto>> GetUserAccountAsync(int id)
    {
        var user = await _userAccountRepository.GetAsync(id);

        return user is not null ?
            Ok(user) :
            NotFound($"User with ID {id} not found.");
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAccountAsync(UserAccount newUser)
    {
        if (newUser is null) 
            return BadRequest("Invalid user account data.");

        if (await _userAccountRepository.IsUserExistsAsync(newUser.Username))
            return Conflict("Username is already taken.");

        var isAdded = await _userAccountRepository.AddAsync(newUser);
        return isAdded ?
            NoContent() :
            StatusCode(StatusCodes.Status500InternalServerError, "Error adding user account.");
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAccountAsync(int id, UserAccount userAccount)
    {
        if (id != userAccount.Id)
            return BadRequest("User ID mismatch.");

        if (await _userAccountRepository.IsUserExistsAsync(userAccount.Username))
            return Conflict("Username is already taken.");

        var isUpdated = await _userAccountRepository.UpdateAsync(mapper.Map<UserAccount>(userAccount));

        return isUpdated ?
            NoContent() : 
            NotFound($"User with ID {id} not found.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int id)
    {
        var isDeleted = await _userAccountRepository.DeleteAsync(id);
        return isDeleted
            ? NoContent()
            : NotFound($"User with ID {id} not found.");
    }
    
 }
