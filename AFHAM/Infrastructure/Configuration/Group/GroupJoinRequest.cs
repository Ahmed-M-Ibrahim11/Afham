using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GroupJoinRequestConfiguration
    : IEntityTypeConfiguration<GroupJoinRequest>
{
    public void Configure(EntityTypeBuilder<GroupJoinRequest> builder)
    {
        builder.ToTable("GroupJoinRequests");

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

        // Status
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        // RequestedAt
        builder.Property(x => x.RequestedAt)
            .IsRequired();

        // RespondedAt
        builder.Property(x => x.RespondedAt);

        // Student -> Join Requests
        builder.HasOne(x => x.Student)
            .WithMany(x => x.JoinRequests)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Group -> Join Requests
        builder.HasOne(x => x.Group)
            .WithMany(x => x.JoinRequests)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Prevent duplicate request for same student and group
        builder.HasIndex(x => new
        {
            x.StudentId,
            x.GroupId
        })
        .IsUnique();
    }
}