using System;
using CNCSproject.Models;

namespace CNCSapi.Interface;

public interface IActivityLogRepository
{
    Task<IEnumerable<ActivityLog>> GetAllAsync();
}
