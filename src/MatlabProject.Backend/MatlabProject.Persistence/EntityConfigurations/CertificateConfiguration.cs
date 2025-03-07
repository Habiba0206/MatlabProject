using MatlabProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatlabProject.Persistence.EntityConfigurations;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.Property(c => c.IssuedAt)
           .IsRequired();

        builder.Property(c => c.FilePath)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(c => c.User)
            .WithMany(u => u.Certificates)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Test)
            .WithMany()
            .HasForeignKey(c => c.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
