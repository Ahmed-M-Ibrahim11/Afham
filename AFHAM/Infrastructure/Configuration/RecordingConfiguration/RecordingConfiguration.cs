using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class RecordingConfiguration
    : IEntityTypeConfiguration<Recording>
{
    public void Configure(EntityTypeBuilder<Recording> builder)
    {
        builder.ToTable("Recordings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.VideoUrl)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.Duration);

        builder.HasIndex(x => x.MeetingId)
            .IsUnique();

        builder.HasOne(x => x.Meeting)
            .WithOne(x => x.Recording)
            .HasForeignKey<Recording>(x => x.MeetingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}