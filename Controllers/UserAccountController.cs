using AutoMapper;
using CNCSapi.Dto;
using CNCSproject.Dto;
using CNCSproject.Interface;
using CNCSproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSproject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController(IUserAccountRepository userAccountRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAccountDto>>> GetUserAccountsAsync()
    {
        var users = await userAccountRepository.GetAllAsync();

        if (!users.Any()) return NotFound("Not found.");

        return Ok(users);
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetUserAccountAsync))] //this code resolve the issue of CreatedAtAction when putting "Async" word in its parameter
    public async Task<ActionResult<UserAccountDto>> GetUserAccountAsync(int id)
    {
        var user = await userAccountRepository.GetAsync(id); 

        if (user is null) return NotFound("Not found."); 

        return user; 
    }

    [HttpPost]
public async Task<IActionResult> AddUserAccountAsync(UserAccountDto userAccountDto)
{
    if (userAccountDto is null) return BadRequest("Invalid user account data.");

    // Map the DTO to the entity and save it
    var userAccount = new UserAccount
    {
        FullName = userAccountDto.FullName,
        Username = userAccountDto.Username,
        Password = userAccountDto.Password,
        UserGroup = userAccountDto.UserGroup,
        Status = userAccountDto.Status,
        DateAdded = DateTime.UtcNow,  // Set the current date
        AddedBy = userAccountDto.AddedBy, 
        IsDeleted = false,
        LogId = $"JXF{userAccountDto.Username}"
    };

    await userAccountRepository.AddAsync(userAccount);

    //I set to null to hide the details in API response
    if (await userAccountRepository.SaveAllAsync()) return CreatedAtAction(nameof(GetUserAccountAsync), new { id = userAccount.Id }, null); 

    return StatusCode(StatusCodes.Status500InternalServerError, "Error adding user account.");
}



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAccountAsync(int id, UserAccount userAccount)
    {
        if (id != userAccount.Id) return BadRequest("User ID mismatch.");

        var isUpdated = await userAccountRepository.UpdateAsync(userAccount);

        if (!isUpdated) return NotFound($"User with ID {id} not found.");

        if (await userAccountRepository.SaveAllAsync()) return NoContent(); // 204 No Content

        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user account.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAccountAsync(int id)
    {
        var isDeleted = await userAccountRepository.DeleteAsync(id);

        if (!isDeleted) return NotFound($"User with ID {id} not found.");

        if (await userAccountRepository.SaveAllAsync()) return NoContent(); // 204 No Content

        return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user account.");
    }
    
 }
