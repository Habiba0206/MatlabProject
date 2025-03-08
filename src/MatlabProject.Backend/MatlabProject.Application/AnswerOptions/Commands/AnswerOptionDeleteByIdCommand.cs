using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.AnswerOptions.Commands;

public class AnswerOptionDeleteByIdCommand : ICommand<bool>
{
    public Guid AnswerOptionId { get; set; }
}
