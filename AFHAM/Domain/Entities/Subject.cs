using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Entities;

public class Subject : Auditable
{

    public string Name { get; private set; } = null!;

    //public string? Icon { get; private set; }

    //public string? Color { get; private set; }

    public int DisplayOrder { get; private set; }

    private readonly List<TeacherProfile> _teachers = [];

    public IReadOnlyCollection<TeacherProfile> Teachers => _teachers;

    // EF Core
    private Subject()
    {
    }

    public Subject(
        string name,
        //string? icon = null,
        //string? color = null,
        int displayOrder = 0)
    {
        Name = name;
        //Icon = icon;
        //Color = color;
        DisplayOrder = displayOrder;
    }

    public void Update(
        string name,
        string? icon,
        string? color,
        int displayOrder)
    {
        Name = name;
        //Icon = icon;
        //Color = color;
        DisplayOrder = displayOrder;
    }

}
