﻿using System;
using System.Collections.Generic;

namespace CNCSproject.Models;

public partial class Transactions
{
    public int Id { get; set; }

    public string? TransactionId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? PickUpDate { get; set; }

    public DateTime? TakeOffDate { get; set; }

    public long? Duration { get; set; }

    public int? ProductVenderId { get; set; }

    public int? DescriptionId { get; set; }

    public string? Remark { get; set; }

    public string? RepliedBy { get; set; }

    public string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? Shift { get; set; }

    public string? TransactionType { get; set; }

    public string? LogId { get; set; }

    public bool? IsDeleted { get; set; }
}
