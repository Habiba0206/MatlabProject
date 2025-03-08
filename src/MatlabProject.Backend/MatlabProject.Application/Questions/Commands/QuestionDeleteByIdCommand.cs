using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.Questions.Commands;

public class QuestionDeleteByIdCommand : ICommand<bool>
{
    public Guid QuestionId { get; set; }
}
