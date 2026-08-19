using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class GroupJoinRequest : Auditable
{

    public Guid StudentId { get; private set; }

    public Guid GroupId { get; private set; }

    public JoinRequestStatus Status { get; private set; }

    public DateTimeOffset RequestedAt { get; private set; }

    public DateTimeOffset? RespondedAt { get; private set; }

    // Navigation

    public StudentProfile Student { get; private set; } = null!;

    public TeacherGroup Group { get; private set; } = null!;

    // EF Core
    private GroupJoinRequest()
    {
    }

    // Factory
    public static GroupJoinRequest Create(
        Guid studentId,
        Guid groupId)
    {
        if (studentId == Guid.Empty)
            throw new ArgumentException(
                "StudentId is required.",
                nameof(studentId));

        if (groupId == Guid.Empty)
            throw new ArgumentException(
                "GroupId is required.",
                nameof(groupId));

        return new GroupJoinRequest
        {
            StudentId = studentId,
            GroupId = groupId,
            Status = JoinRequestStatus.Pending,
            RequestedAt = DateTimeOffset.UtcNow
        };
    }

    public void Accept()
    {
        if (Status != JoinRequestStatus.Pending)
            throw new InvalidOperationException(
                "Only pending requests can be accepted.");

        Status = JoinRequestStatus.Accepted;
        RespondedAt = DateTimeOffset.UtcNow;
    }

    public void Reject()
    {
        if (Status != JoinRequestStatus.Pending)
            throw new InvalidOperationException(
                "Only pending requests can be rejected.");

        Status = JoinRequestStatus.Rejected;
        RespondedAt = DateTimeOffset.UtcNow;
    }

    public void Cancel()
    {
        if (Status != JoinRequestStatus.Pending)
            throw new InvalidOperationException(
                "Only pending requests can be cancelled.");

        Status = JoinRequestStatus.Cancelled;
        RespondedAt = DateTimeOffset.UtcNow;
    }
}