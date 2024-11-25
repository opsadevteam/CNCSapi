using System;
using CNCSapi.Interface;
using CNCSproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCSapi.Repository;

public class ActivityLogRepository(CncssystemContext context) : IActivityLogRepository
{
    public async Task<IEnumerable<ActivityLog>> GetAllAsync()
    {
        return await context.ActivityLog.ToListAsync();
    }
}
