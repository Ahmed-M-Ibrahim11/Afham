using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Domain.Entities;

public class TeacherGroup : Auditable
{

    public Guid TeacherId { get; private set; }

    public int GradeId { get; private set; }

    public string Name { get; private set; } = null!;

    public int Capacity { get; private set; }

    public string Description { get; private set; } = null!;
    
    public string displayOrder { get; private set; } = null!;
    public EnrollmentStatus EnrollmentStatus { get; private set; }

    public ChatMode ChatMode { get; private set; }

    // Navigation

    public TeacherProfile Teacher { get; private set; } = null!;

    public Grade Grade { get; private set; } = null!;

    private readonly List<GroupMembership> _members = [];

    public IReadOnlyCollection<GroupMembership> Members => _members;
    private readonly List<GroupMembership> _memberships = [];

    public IReadOnlyCollection<GroupMembership> Memberships
        => _memberships;

    private readonly List<GroupJoinRequest> _joinRequests = [];


    public IReadOnlyCollection<GroupJoinRequest> JoinRequests => _joinRequests;

    private readonly List<Meeting> _meetings = [];

    public IReadOnlyCollection<Meeting> Meetings => _meetings;

    private readonly List<Announcement> _announcements = [];

    public IReadOnlyCollection<Announcement> Announcements => _announcements;

    // EF Core
    private TeacherGroup()
    {
    }

    // Factory
    public static TeacherGroup Create(
        Guid teacherId,
        int gradeId,
        string name,
        int capacity)
    {
        if (teacherId == Guid.Empty)
            throw new ArgumentException(
                "TeacherId is required.",
                nameof(teacherId));

        if (gradeId <= 0)
            throw new ArgumentException(
                "GradeId is required.",
                nameof(gradeId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Group name is required.",
                nameof(name));

        if (capacity <= 0)
            throw new ArgumentException(
                "Group capacity must be greater than zero.",
                nameof(capacity));

        return new TeacherGroup
        {
            Id = Guid.NewGuid(),
            TeacherId = teacherId,
            GradeId = gradeId,
            Name = name,
            Capacity = capacity,
            EnrollmentStatus = EnrollmentStatus.Open,
            ChatMode = ChatMode.Closed
        };
    }

    public void Update(
        string name,
        int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Group name is required.",
                nameof(name));

        if (capacity <= 0)
            throw new ArgumentException(
                "Group capacity must be greater than zero.",
                nameof(capacity));

        if (capacity < _members.Count)
            throw new InvalidOperationException(
                "Capacity cannot be less than the current number of members.");

        Name = name;
        Capacity = capacity;
    }

    public void OpenEnrollment()
    {
        EnrollmentStatus = EnrollmentStatus.Open;
    }

    public void CloseEnrollment()
    {
        EnrollmentStatus = EnrollmentStatus.Closed;
    }

    public void ChangeChatMode(ChatMode chatMode)
    {
        ChatMode = chatMode;
    }
}