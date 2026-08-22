using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Master Data
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Grade> Grades => Set<Grade>();

    // Profiles
    public DbSet<TeacherProfile> TeacherProfiles => Set<TeacherProfile>();
    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();

    // Core Business
    public DbSet<TeacherGroup> TeacherGroups => Set<TeacherGroup>();
    public DbSet<GroupJoinRequest> GroupJoinRequests => Set<GroupJoinRequest>();
    public DbSet<GroupMembership> GroupMemberships => Set<GroupMembership>();

    // Learning
    public DbSet<Meeting> Meetings => Set<Meeting>();
    public DbSet<Recording> Recordings => Set<Recording>();
    public DbSet<Announcement> Announcements => Set<Announcement>();

    // Communication
    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}