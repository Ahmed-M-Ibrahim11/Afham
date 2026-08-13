using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class Grade : Auditable
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public int DisplayOrder { get; private set; }

    private readonly List<StudentProfile> _students = [];
    public IReadOnlyCollection<StudentProfile> Students => _students;

    private readonly List<TeacherGroup> _teacherGroups = [];
    public IReadOnlyCollection<TeacherGroup> TeacherGroups => _teacherGroups;

    // EF Core
    private Grade()
    {
    }

    public Grade(
        string name,
        int displayOrder = 0)
    {
        Name = name;
        DisplayOrder = displayOrder;
    }

    public void Update(
        string name,
        int displayOrder)
    {
        Name = name;
        DisplayOrder = displayOrder;
    }

}