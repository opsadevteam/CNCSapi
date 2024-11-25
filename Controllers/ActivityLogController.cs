using CNCSapi.Repository;
using CNCSproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNCSapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController(ActivityLogRepository _activityLogRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLog>>> GetActivityLogs()
        {
            var users = await _activityLogRepository.GetAllAsync();

            return users.Any() ?
                Ok(users) :
                NotFound("No data found.");
        }
    }
}
