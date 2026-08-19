using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TeacherProfileConfiguration
    : IEntityTypeConfiguration<TeacherProfile>
{
    public void Configure(EntityTypeBuilder<TeacherProfile> builder)
    {
        builder.ToTable("TeacherProfiles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        //builder.Property(x => x.DisplayName)
        //    .IsRequired()
        //    .HasMaxLength(150);

        //builder.Property(x => x.ImageUrl)
        //    .HasMaxLength(500);

        builder.Property(x => x.Bio)
            .HasMaxLength(1000);

        builder.Property(x => x.ExperienceYears)
            .IsRequired();

        builder.Property(x => x.Rating)
            .HasPrecision(3, 2);

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Teachers)
            .HasForeignKey(x => x.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}