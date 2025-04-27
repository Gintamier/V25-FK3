namespace SchoolDB_API.Models;

using Microsoft.EntityFrameworkCore;
using SchoolDB_API.Models;


public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<SchoolGroup> Groups { get; set; }
    public DbSet<Teachers> Teachers { get; set; }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<SubjectTeachers> SubjectTeachers { get; set; }
    public DbSet<Mark> Marks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectTeachers>()
            .HasKey(st => new { st.SubjectId, st.TeacherId });

        modelBuilder.Entity<SubjectTeachers>()
            .HasOne(st => st.Subject)
            .WithMany(s => s.SubjectTeachers)
            .HasForeignKey(st => st.SubjectId);

        modelBuilder.Entity<SubjectTeachers>()
            .HasOne(st => st.Teacher)
            .WithMany(t => t.SubjectTeachers)
            .HasForeignKey(st => st.TeacherId);
    }
}