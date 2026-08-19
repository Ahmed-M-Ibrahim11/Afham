using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentProfileConfiguration
    : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.ToTable("StudentProfiles");

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

        builder.Property(x => x.ParentName)
            .HasMaxLength(150);

        builder.Property(x => x.ParentPhone)
            .HasMaxLength(30);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}