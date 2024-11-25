﻿using System;
using System.Collections.Generic;

namespace CNCSproject.Models;

public partial class ProdDescLog
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? LogId { get; set; }

    public string? LogDetails { get; set; }

    public string? LogActivity { get; set; }

    public string? LogUser { get; set; }

    public DateTime? LogDate { get; set; }
}
