using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Entities;

public class StudentProfile : Auditable
{
    public Guid UserId { get; private set; }

    public int GradeId { get; private set; }

    public string? ProfileImage { get; private set; }

    // Navigation

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