using System;

namespace CNCSapi.Dto;

public class UserAccountDto
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserGroup { get; set; }

    public string? Status { get; set; }

    public DateTime? DateAdded { get; set; }

}
