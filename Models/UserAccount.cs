using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CNCSproject.Models;

public class UserAccount
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

    [Required]
    public required string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LogId { get; set; }

}
