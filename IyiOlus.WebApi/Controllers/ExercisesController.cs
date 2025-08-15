using IyiOlus.Application.Features.Exercises.Commands.Create;
using IyiOlus.Application.Features.Exercises.Commands.Delete;
using IyiOlus.Application.Features.Exercises.Commands.Update;
using IyiOlus.Application.Features.Exercises.Queries.GetById;
using IyiOlus.Application.Features.Exercises.Queries.GetList;
using IyiOlus.Application.Features.Exercises.Queries.GetListByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Create([FromBody]CreateExerciseCommand createExerciseCommand)
        {
            var result = await Mediator.Send(createExerciseCommand);
            return Created("", result);
        }

        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Update([FromBody]UpdateExerciseCommand updateExerciseCommand)
        {
            var ressult = await Mediator.Send(updateExerciseCommand);
            return Ok(ressult);
        }

        [HttpDelete]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteExerciseCommand { ExerciseId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize("admin,user")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdExerciseQuery { ExerciseId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> GetList([FromQuery]GetListExerciseQuery getListExerciseQuery)
        {
            var result = await Mediator.Send(getListExerciseQuery);
            return Ok(result);
        }

        [HttpGet("user")]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> GetListByUserId([FromQuery]GetListByUserIdExerciseQuery getListByUserIdExerciseQuery)
        {
            var result = await Mediator.Send(getListByUserIdExerciseQuery);
            return Ok(result);
        }

    }
}
