using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GradeConfiguration
    : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");

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

        // Grade -> Students
        builder.HasMany(x => x.Students)
            .WithOne(x => x.Grade)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Grade -> Groups
        builder.HasMany(x => x.TeacherGroups)
                .WithOne(x => x.Grade)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index
        builder.HasIndex(x => x.DisplayOrder);
    }
}