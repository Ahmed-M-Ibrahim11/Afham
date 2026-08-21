using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ChatMessageConfiguration
    : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.ToTable("ChatMessages");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Database generates Sequential GUID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        // GroupId
        builder.Property(x => x.GroupId)
            .IsRequired();

        // SenderId
        builder.Property(x => x.SenderId)
            .IsRequired();

        // Content
        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(4000);

        // SentAt
        builder.Property(x => x.SentAt)
            .IsRequired();

        // IsEdited
        builder.Property(x => x.IsEdited)
            .IsRequired();

        // EditedAt
        builder.Property(x => x.EditedAt);

        // Group -> ChatMessages
        builder.HasOne(x => x.Group)
            .WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.GroupId);

        builder.HasIndex(x => x.SentAt);
    }
}