using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class TeacherProfile : Auditable
{
    public Guid UserId { get; private set; }

    public int SubjectId { get; private set; }

    public string? ProfileImage { get; private set; }

    public string? Bio { get; private set; }

    public int? ExperienceYears { get; private set; }

    public decimal Rating { get; private set; }

    // Navigation Properties

    public Subject Subject { get; private set; } = null!;

    private readonly List<TeacherGroup> _groups = [];
    public IReadOnlyCollection<TeacherGroup> Groups => _groups;

    // EF Core
    private TeacherProfile()
    {
    }

    public TeacherProfile(
        Guid userId,
        int subjectId,
        string? profileImage = null,
        string? bio = null,
        int? experienceYears = null)
    {
        UserId = userId;
        SubjectId = subjectId;
        ProfileImage = profileImage;
        Bio = bio;
        ExperienceYears = experienceYears;
        Rating = 0;
    }

    public void Update(
        int subjectId,
        string? profileImage,
        string? bio,
        int? experienceYears)
    {
        SubjectId = subjectId;
        ProfileImage = profileImage;
        Bio = bio;
        ExperienceYears = experienceYears;
    }

    public void UpdateRating(decimal rating)
    {
        Rating = rating;
    }
}
