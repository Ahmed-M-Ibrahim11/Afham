using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ChatMessage : Auditable
    {

        public Guid GroupId { get; private set; }

        public Guid SenderId { get; private set; }

        public string Content { get; private set; } = null!;

        public DateTimeOffset SentAt { get; private set; }

        public bool IsEdited { get; private set; }

        public DateTimeOffset? EditedAt { get; private set; }

        // Navigation

        public TeacherGroup Group { get; private set; } = null!;

        // EF Core
        private ChatMessage()
        {
        }

        public static ChatMessage Create(
            Guid groupId,
            Guid senderId,
            string content)
        {
            if (groupId == Guid.Empty)
                throw new ArgumentException(
                    "GroupId is required.",
                    nameof(groupId));

            if (senderId == Guid.Empty)
                throw new ArgumentException(
                    "SenderId is required.",
                    nameof(senderId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException(
                    "Message content is required.",
                    nameof(content));

            return new ChatMessage
            {
                GroupId = groupId,
                SenderId = senderId,
                Content = content,
                SentAt = DateTimeOffset.UtcNow
            };
        }
    }
}
