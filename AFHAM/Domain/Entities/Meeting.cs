using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Meeting : Auditable
    {

        public Guid GroupId { get; private set; }

        public string Title { get; private set; } = null!;

        public MeetingProvider Provider { get; private set; }

        public MeetingStatus Status { get; private set; }

        public string JoinUrl { get; private set; } = null!;

        public DateTimeOffset ScheduledAt { get; private set; }

        public DateTimeOffset? StartedAt { get; private set; }

        public DateTimeOffset? EndedAt { get; private set; }

        // Navigation

        public TeacherGroup Group { get; private set; } = null!;

        public Recording? Recording { get; private set; }

        // EF Core
        private Meeting()
        {
        }

        // Factory
        public static Meeting Create(
            Guid groupId,
            string title,
            MeetingProvider provider,
            string joinUrl,
            DateTimeOffset scheduledAt)
        {
            if (groupId == Guid.Empty)
                throw new ArgumentException(
                    "GroupId is required.",
                    nameof(groupId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Meeting title is required.",
                    nameof(title));

            if (string.IsNullOrWhiteSpace(joinUrl))
                throw new ArgumentException(
                    "Meeting URL is required.",
                    nameof(joinUrl));

            return new Meeting
            {
                Id = Guid.NewGuid(),
                GroupId = groupId,
                Title = title,
                Provider = provider,
                JoinUrl = joinUrl,
                ScheduledAt = scheduledAt,
                Status = MeetingStatus.Scheduled
            };
        }

        public void Start(DateTimeOffset startedAt)
        {
            if (Status != MeetingStatus.Scheduled)
                throw new InvalidOperationException(
                    "Only scheduled meetings can be started.");

            Status = MeetingStatus.Live;
            StartedAt = startedAt;
        }

        public void Complete(DateTimeOffset endedAt)
        {
            if (Status != MeetingStatus.Live)
                throw new InvalidOperationException(
                    "Only live meetings can be completed.");

            if (endedAt < StartedAt)
                throw new ArgumentException(
                    "End time cannot be before start time.",
                    nameof(endedAt));

            Status = MeetingStatus.Completed;
            EndedAt = endedAt;
        }

        public void Cancel()
        {
            if (Status != MeetingStatus.Scheduled)
                throw new InvalidOperationException(
                    "Only scheduled meetings can be cancelled.");

            Status = MeetingStatus.Cancelled;
        }
    }
}
