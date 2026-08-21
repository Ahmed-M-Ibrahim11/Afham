using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AnnouncementConfiguration
    : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Database generates Sequential GUID
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

        // Content
        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(5000);

        // PublishedAt
        builder.Property(x => x.PublishedAt)
            .IsRequired();

        // IsPublished
        builder.Property(x => x.IsPublished)
            .IsRequired();

        // Group -> Announcements
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Announcements)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index
        builder.HasIndex(x => x.GroupId);

        builder.HasIndex(x => x.PublishedAt);
    }
}