using IyiOlus.Application.Features.Questions.Commands.Create;
using IyiOlus.Application.Features.Questions.Commands.Delete;
using IyiOlus.Application.Features.Questions.Commands.Update;
using IyiOlus.Application.Features.Questions.Queries.GetById;
using IyiOlus.Application.Features.Questions.Queries.GetList;
using IyiOlus.Application.Features.Questions.Queries.GetListByQuestionType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IyiOlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        [HttpPost]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> Create([FromBody]CreateQuestionCommand createQuestionCommand)
        {
            var result = await Mediator.Send(createQuestionCommand);
            return Created("", result);
        }

        [HttpPut]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody]UpdateQuestionCommand updateQuestionCommand)
        {
            var result = await Mediator.Send(updateQuestionCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteQuestionCommand { QuestionId = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var query = new GetByIdQuestionQuery { QuestionId = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetList([FromQuery]GetListQuestionQuery getListQuestionQuery)
        {
            var result = await Mediator.Send(getListQuestionQuery);
            return Ok(result);
        }

        [HttpGet("type")]
        //[Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetListByQuestionType([FromQuery]GetListByQuestionTypeQuestionQuery getListByQuestionTypeQuestionQuery)
        {
            var result = await Mediator.Send(getListByQuestionTypeQuestionQuery);
            return Ok(result);
        }
    }
}
