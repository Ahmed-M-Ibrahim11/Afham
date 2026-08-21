using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MeetingConfiguration
    : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.ToTable("Meetings");

        // Primary Key
        builder.HasKey(x => x.Id);

        // SQL Server generates Sequential GUID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        // GroupId
        builder.Property(x => x.GroupId)
            .IsRequired();

        // Title
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        // Provider
        builder.Property(x => x.Provider)
            .IsRequired()
            .HasConversion<int>();

        // Status
        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        // JoinUrl
        builder.Property(x => x.JoinUrl)
            .IsRequired()
            .HasMaxLength(1000);

        // ScheduledAt
        builder.Property(x => x.ScheduledAt)
            .IsRequired();

        // StartedAt
        builder.Property(x => x.StartedAt);

        // EndedAt
        builder.Property(x => x.EndedAt);

        // Group -> Meetings
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Meetings)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // GroupId Index
        builder.HasIndex(x => x.GroupId);

        // ScheduledAt Index
        builder.HasIndex(x => x.ScheduledAt);
    }
}