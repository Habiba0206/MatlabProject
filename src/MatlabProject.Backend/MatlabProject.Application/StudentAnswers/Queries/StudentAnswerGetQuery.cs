using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.StudentAnswers.Models;

namespace MatlabProject.Application.StudentAnswers.Queries;

public class StudentAnswerGetQuery : IQuery<ICollection<StudentAnswerDto>>
{
    public StudentAnswerFilter StudentAnswerFilter { get; set; }
}
