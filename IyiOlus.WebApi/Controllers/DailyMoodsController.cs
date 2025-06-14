using IyiOlus.Application.Features.DailyMoods.Commands.Create;
using IyiOlus.Application.Features.DailyMoods.Queries.GetById;
using IyiOlus.Application.Features.DailyMoods.Queries.GetList;
using IyiOlus.Application.Features.DailyMoods.Queries.GetListDailyMoodByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMoodsController : BaseController
    {
        [HttpPost]
        [Authorize(Roles ="user")]
        public async Task<IActionResult> Create([FromBody]CreateDailyMoodCommand createDailyMoodCommand)
        {
            var result = await Mediator.Send(createDailyMoodCommand);
            return Created("", result);
        }

        [HttpGet("{id}")]
        [Authorize("admin,user")]  // GetByID kısımlarındaki user durumla göre, entity'e göre kaldırılabilir
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdDailyMoodQuery { DailyMoodId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> GetList([FromQuery] GetListDailyMoodQuery getListDailyMoodQuery)
        {
            var result = await Mediator.Send(getListDailyMoodQuery);
            return Ok(result);
        }

        [HttpGet("get")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Get([FromQuery]GetListDailyMoodByUserIdCommand getListDailyMoodByUserIdCommand)
        {
            var result = await Mediator.Send(getListDailyMoodByUserIdCommand);
            return Ok(result);
        }
    }
}
