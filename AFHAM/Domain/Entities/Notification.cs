using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Notification : Auditable
    {

        public Guid UserId { get; private set; }

        public NotificationType Type { get; private set; }

        public string Title { get; private set; } = null!;

        public string Message { get; private set; } = null!;

        public bool IsRead { get; private set; }

        public Guid? RelatedEntityId { get; private set; }

        // EF Core
        private Notification()
        {
        }

        public static Notification Create(
            Guid userId,
            NotificationType type,
            string title,
            string message,
            Guid? relatedEntityId = null)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException(
                    "UserId is required.",
                    nameof(userId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Notification title is required.",
                    nameof(title));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException(
                    "Notification message is required.",
                    nameof(message));

            return new Notification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = type,
                Title = title,
                Message = message,
                IsRead = false,
                RelatedEntityId = relatedEntityId
            };
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }

        public void MarkAsUnread()
        {
            IsRead = false;
        }
    }
}
