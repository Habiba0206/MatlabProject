using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Questions.Models;

namespace MatlabProject.Application.Questions.Queries;

public class QuestionGetQuery : IQuery<ICollection<QuestionDto>>
{
    public QuestionFilter QuestionFilter { get; set; }
}
