using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SubjectConfiguration
    : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Database generates Sequential GUID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        // Name
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        // DisplayOrder
        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        // Relationship
        builder.HasMany(x => x.Teachers)
            .WithOne(x => x.Subject)
            .HasForeignKey(x => x.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index
        builder.HasIndex(x => x.DisplayOrder);
    }
}