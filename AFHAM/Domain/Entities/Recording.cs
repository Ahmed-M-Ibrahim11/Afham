using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Recording : Auditable
    {

        public Guid MeetingId { get; private set; }

        public string VideoUrl { get; private set; } = null!;

        public DateTimeOffset RecordedAt { get; private set; }

        public TimeSpan? Duration { get; private set; }

        // Navigation

        public Meeting Meeting { get; private set; } = null!;

        // EF Core
        private Recording()
        {
        }

        // Factory
        public static Recording Create(
            Guid meetingId,
            string videoUrl,
            DateTimeOffset recordedAt,
            TimeSpan? duration = null)
        {
            if (meetingId == Guid.Empty)
                throw new ArgumentException(
                    "MeetingId is required.",
                    nameof(meetingId));

            if (string.IsNullOrWhiteSpace(videoUrl))
                throw new ArgumentException(
                    "Video URL is required.",
                    nameof(videoUrl));

            if (duration.HasValue && duration.Value < TimeSpan.Zero)
                throw new ArgumentException(
                    "Duration cannot be negative.",
                    nameof(duration));

            return new Recording
            {
                Id = Guid.NewGuid(),
                MeetingId = meetingId,
                VideoUrl = videoUrl,
                RecordedAt = recordedAt,
                Duration = duration
            };
        }

        public void UpdateVideo(
            string videoUrl,
            TimeSpan? duration)
        {
            if (string.IsNullOrWhiteSpace(videoUrl))
                throw new ArgumentException(
                    "Video URL is required.",
                    nameof(videoUrl));

            if (duration.HasValue && duration.Value < TimeSpan.Zero)
                throw new ArgumentException(
                    "Duration cannot be negative.",
                    nameof(duration));

            VideoUrl = videoUrl;
            Duration = duration;
        }
    }
}
