using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestResultsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] TestResultGetQuery testResultGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(testResultGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{testResultId:guid}")]
    public async ValueTask<IActionResult> GetAnswerById([FromRoute] Guid testResultId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TestResultGetByIdQuery { TestResultId = testResultId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAnswer([FromBody] TestResultCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAnswer([FromBody] TestResultUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{testResultId:guid}")]
    public async ValueTask<IActionResult> DeleteAnswerById([FromRoute] Guid testResultId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TestResultDeleteByIdCommand { TestResultId = testResultId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
