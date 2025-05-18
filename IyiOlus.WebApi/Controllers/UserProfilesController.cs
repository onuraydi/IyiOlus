using IyiOlus.Application.Features.ProfileTypes.Commands.Update;
using IyiOlus.Application.Features.UserProfiles.Commands.Create;
using IyiOlus.Application.Features.UserProfiles.Commands.Delete;
using IyiOlus.Application.Features.UserProfiles.Commands.Update;
using IyiOlus.Application.Features.UserProfiles.Queries.GetById;
using IyiOlus.Application.Features.UserProfiles.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserProfileCommand createUserProfileCommand)
        {
            var result = await Mediator.Send(createUserProfileCommand);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateUserProfileCommand updateUserProfileCommand)
        {
            var result = await Mediator.Send(updateUserProfileCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteUserProfileCommand { userProfileId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdUserProfileQuery { UserProfileId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]GetListUserProfileQuery getListUserProfileQuery)
        {
            var result = await Mediator.Send(getListUserProfileQuery);
            return Ok(result);
        }
    }
}
