using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Entities;

public class StudentProfile : Auditable
{
    public Guid UserId { get; private set; }

    public int GradeId { get; private set; }

    public string? ProfileImage { get; private set; }

    public string ParentName { get; private set; } = null!;

    public int? ParentPhone { get; private set; }

    // Navigation
    private readonly List<GroupJoinRequest> _joinRequests = [];

    public IReadOnlyCollection<GroupJoinRequest> JoinRequests
        => _joinRequests;
    private readonly List<GroupMembership> _groupMemberships = [];

    public IReadOnlyCollection<GroupMembership> GroupMemberships
        => _groupMemberships;
    public Grade Grade { get; private set; } = null!;

    private StudentProfile()
    {
    }

    // Create
    public StudentProfile(
        Guid userId,
        int gradeId,
        string? profileImage = null)
    {
        UserId = userId;
        GradeId = gradeId;
        ProfileImage = profileImage;
    }

    // Update
    public void Update(
        int gradeId,
        string? profileImage)
    {
        GradeId = gradeId;
        ProfileImage = profileImage;
    }
}