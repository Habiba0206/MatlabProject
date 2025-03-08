using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Questions.Models;

namespace MatlabProject.Application.Questions.Queries;

public class QuestionGetByIdQuery : IQuery<QuestionDto?>
{
    public Guid QuestionId { get; set; }
}
