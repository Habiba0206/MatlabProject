using MatlabProject.Application.StudentAnswers.Commands;
using MatlabProject.Application.StudentAnswers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentAnswersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] StudentAnswerGetQuery studentAnswerGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(studentAnswerGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{studentAnswerId:guid}")]
    public async ValueTask<IActionResult> GetStudentAnswerById([FromRoute] Guid studentAnswerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new StudentAnswerGetByIdQuery { StudentAnswerId = studentAnswerId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAnswer([FromBody] StudentAnswerCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAnswer([FromBody] StudentAnswerUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{studentAnswerId:guid}")]
    public async ValueTask<IActionResult> DeleteAnswerById([FromRoute] Guid studentAnswerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new StudentAnswerDeleteByIdCommand { StudentAnswerId = studentAnswerId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
