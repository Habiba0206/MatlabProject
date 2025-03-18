using MatlabProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatlabProject.Persistence.EntityConfigurations;

public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
{
    public void Configure(EntityTypeBuilder<StudentAnswer> builder)
    {
        builder.Property(sa => sa.SelectedAnswer)
            .IsRequired();

        builder.Property(sa => sa.IsCorrect)
            .IsRequired();

        builder.HasOne(sa => sa.TestResult)
            .WithMany(tr => tr.StudentAnswers)
            .HasForeignKey(sa => sa.TestResultId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
