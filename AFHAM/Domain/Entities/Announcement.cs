using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Announcement : Auditable
    {

        public Guid GroupId { get; private set; }

        public string Title { get; private set; } = null!;

        public string Content { get; private set; } = null!;

        public DateTimeOffset PublishedAt { get; private set; }

        public bool IsPublished { get; private set; }

        // Navigation

        public TeacherGroup Group { get; private set; } = null!;

        // EF Core
        private Announcement()
        {
        }

        // Factory
        public static Announcement Create(
            Guid groupId,
            string title,
            string content)
        {
            if (groupId == Guid.Empty)
                throw new ArgumentException(
                    "GroupId is required.",
                    nameof(groupId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Announcement title is required.",
                    nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException(
                    "Announcement content is required.",
                    nameof(content));

            return new Announcement
            {
                GroupId = groupId,
                Title = title,
                Content = content,
                PublishedAt = DateTimeOffset.UtcNow,
                IsPublished = true
            };
        }

        public void Update(
            string title,
            string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Announcement title is required.",
                    nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException(
                    "Announcement content is required.",
                    nameof(content));

            Title = title;
            Content = content;
        }

        public void Publish()
        {
            IsPublished = true;
            PublishedAt = DateTimeOffset.UtcNow;
        }

        public void Unpublish()
        {
            IsPublished = false;
        }
    }
}
