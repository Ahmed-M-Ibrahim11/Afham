using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GroupMembershipConfiguration
    : IEntityTypeConfiguration<GroupMembership>
{
    public void Configure(EntityTypeBuilder<GroupMembership> builder)
    {
        builder.ToTable("GroupMemberships");

        // Primary Key
        builder.HasKey(x => x.Id);

        // SQL Server generates Sequential GUID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        // StudentId
        builder.Property(x => x.StudentId)
            .IsRequired();

        // GroupId
        builder.Property(x => x.GroupId)
            .IsRequired();

        // Membership Status
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        // JoinedAt
        builder.Property(x => x.JoinedAt)
            .IsRequired();

        // RemovedAt
        builder.Property(x => x.RemovedAt);

        // Student -> Memberships
        builder.HasOne(x => x.Student)
            .WithMany(x => x.GroupMemberships)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Group -> Memberships
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Memberships)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Prevent duplicate membership in the same group
        builder.HasIndex(x => new
        {
            x.StudentId,
            x.GroupId
        })
        .IsUnique();

        // Querying memberships by Student
        builder.HasIndex(x => x.StudentId);

        // Querying members by Group
        builder.HasIndex(x => x.GroupId);
    }
}