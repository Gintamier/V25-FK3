namespace SchoolDB_ERD;
using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public DbSet<Student> Student { get; set; }
    public DbSet<SchoolGroup> Group { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<SubjectTeacher> SubjectTeacher { get; set; }
    public DbSet<Mark> Mark { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=school.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many relationship between Subjects and Teachers
        modelBuilder.Entity<SubjectTeacher>()
            .HasKey(st => new { st.SubjectId, st.TeacherId });

        modelBuilder.Entity<SubjectTeacher>()
            .HasOne(st => st.Subject)
            .WithMany(s => s.SubjectTeachers)
            .HasForeignKey(st => st.SubjectId);

        modelBuilder.Entity<SubjectTeacher>()
            .HasOne(st => st.Teacher)
            .WithMany(t => t.SubjectTeachers)
            .HasForeignKey(st => st.TeacherId);
    }
}
