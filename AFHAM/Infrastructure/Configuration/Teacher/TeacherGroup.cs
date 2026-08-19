using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TeacherGroupConfiguration
    : IEntityTypeConfiguration<TeacherGroup>
{
    public void Configure(EntityTypeBuilder<TeacherGroup> builder)
    {
        builder.ToTable("TeacherGroups");

        // Primary Key
        builder.HasKey(x => x.Id);

        // SQL Server generates Sequential GUID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        // TeacherId
        builder.Property(x => x.TeacherId)
            .IsRequired();

        // GradeId
        builder.Property(x => x.GradeId)
            .IsRequired();

        // Name
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        // Capacity
        builder.Property(x => x.Capacity)
            .IsRequired();

        // EnrollmentStatus
        builder.Property(x => x.EnrollmentStatus)
            .IsRequired()
            .HasConversion<int>();

        // ChatMode
        builder.Property(x => x.ChatMode)
            .IsRequired()
            .HasConversion<int>();

        // Teacher -> Groups
        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Groups)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        // Grade -> Groups
        builder.HasOne(x => x.Grade)
            .WithMany(x => x.TeacherGroups)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.TeacherId);

        builder.HasIndex(x => x.GradeId);
    }
}