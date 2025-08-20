using IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Queries;
using IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : BaseController
    {
        [HttpGet("DailyMood")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetList([FromQuery] DailyMoodStatisticQuery dailyMoodStatisticQuery)
        {
            var result = await Mediator.Send(dailyMoodStatisticQuery);
            return Ok(result);
        }

        [HttpGet("UserProfile")]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> GetList([FromQuery] UserProfilesStatisticQuery userProfilesStatisticQuery)
        {
            var result = await Mediator.Send(userProfilesStatisticQuery);
            return Ok(result);
        }
    }
}
