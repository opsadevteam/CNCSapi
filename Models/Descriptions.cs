using System;
using System.Collections.Generic;

namespace CNCSproject.Models;

public partial class Descriptions
{
    public int Id { get; set; }

    public int? ProductVendorId { get; set; }

    public string? Description { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LogId { get; set; }
}
