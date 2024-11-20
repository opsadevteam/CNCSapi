using System;
using System.Collections.Generic;

namespace CNCSproject.Models;

public partial class ProductVendor
{
    public int Id { get; set; }

    public string? ProductVendor1 { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LogId { get; set; }
}
