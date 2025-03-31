using MatlabProject.Application.AnswerOptions.Commands;
using MatlabProject.Application.AnswerOptions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerOptionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] AnswerOptionGetQuery answerGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(answerGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{answerOptionId:guid}")]
    public async ValueTask<IActionResult> GetAnswerOptionById([FromRoute] Guid answerOptionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new AnswerOptionGetByIdQuery { AnswerOptionId = answerOptionId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAnswerOption([FromBody] AnswerOptionCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAnswerOption([FromBody] AnswerOptionUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{answerOptionId:guid}")]
    public async ValueTask<IActionResult> DeleteAnswerById([FromRoute] Guid answerOptionId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new AnswerOptionDeleteByIdCommand { AnswerOptionId = answerOptionId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
