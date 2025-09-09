using IyiOlus.Application.Features.Notifications.Commands.Create;
using IyiOlus.Application.Features.Notifications.Commands.Update;
using IyiOlus.Application.Features.Notifications.Queries.GetById;
using IyiOlus.Application.Features.Notifications.Queries.GetListByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> Create([FromBody]CreateNotificationCommand createNotificationCommand)
        {
            var result = await Mediator.Send(createNotificationCommand);
            return Created("", result);
        }

        [HttpPut]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> Update([FromBody]UpdateNotificationCommand updateNotificationCommand)
        {
            var result = await Mediator.Send(updateNotificationCommand);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdNotificationQuery { NotificationId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetListByUser([FromQuery]GetListByUserIdNotificationQuery getListByUserIdNotificationQuery)
        {
            var result = await Mediator.Send(getListByUserIdNotificationQuery);
            return Ok(result);
        }
    }
}
