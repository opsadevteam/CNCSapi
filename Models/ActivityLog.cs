using System;
using System.Collections.Generic;

namespace CNCSproject.Models;

public partial class ActivityLog
{
    public int Id { get; set; }

    public string? LogActivity { get; set; }

    public string? LogUser { get; set; }

    public DateTime? LogTime { get; set; }

    public string? LogDetails { get; set; }

    public string? LogLocation { get; set; }

    public string? UserGroup { get; set; }
}
