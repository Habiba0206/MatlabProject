using MatlabProject.Application.Questions.Commands;
using MatlabProject.Application.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] QuestionGetQuery questionGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(questionGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{questionId:guid}")]
    public async ValueTask<IActionResult> GetQuestionById([FromRoute] Guid questionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new QuestionGetByIdQuery { QuestionId = questionId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateQuestion([FromBody] QuestionCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateQuestion([FromBody] QuestionUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{questionId:guid}")]
    public async ValueTask<IActionResult> DeleteQuestionById([FromRoute] Guid questionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new QuestionDeleteByIdCommand { QuestionId = questionId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
