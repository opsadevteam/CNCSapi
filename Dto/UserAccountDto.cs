using System;
using System.ComponentModel.DataAnnotations;

namespace CNCSapi.Dto;

public class UserAccountDto
{
    public int Id { get; set; }

    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required  string UserGroup { get; set; }
    [Required]
    public  required string Status { get; set; }
    public DateTime? DateAdded { get; set; }
    public string? AddedBy { get; set; }
}

public class UpdateUserAccountDto
{
    public int Id { get; set; }

    [Required]
    public required string FullName { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string UserGroup { get; set; }

}

