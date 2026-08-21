using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Entities;

public class GroupMembership : Auditable
{

    public Guid StudentId { get; private set; }

    public Guid GroupId { get; private set; }

    public MembershipStatus Status { get; private set; }

    public DateTimeOffset JoinedAt { get; private set; }

    public DateTimeOffset? RemovedAt { get; private set; }

    // Navigation

    public StudentProfile Student { get; private set; } = null!;

    public TeacherGroup Group { get; private set; } = null!;

    // EF Core
    private GroupMembership()
    {
    }

    // Factory
    public static GroupMembership Create(
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

        return new GroupMembership
        {
            StudentId = studentId,
            GroupId = groupId,
            Status = MembershipStatus.Active,
            JoinedAt = DateTimeOffset.UtcNow
        };
    }

    public void Remove()
    {
        if (Status != MembershipStatus.Active)
            throw new InvalidOperationException(
                "Only active members can be removed.");

        Status = MembershipStatus.Removed;
        RemovedAt = DateTimeOffset.UtcNow;
    }

    public void Reactivate()
    {
        if (Status != MembershipStatus.Removed)
            throw new InvalidOperationException(
                "Only removed members can be reactivated.");

        Status = MembershipStatus.Active;
        RemovedAt = null;
    }
}