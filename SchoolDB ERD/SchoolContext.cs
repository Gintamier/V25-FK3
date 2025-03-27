namespace SchoolDB_ERD;
using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public DbSet<Students> Student { get; set; }
    public DbSet<SchoolGroup> Group { get; set; }
    public DbSet<Teachers> Teacher { get; set; }
    public DbSet<Subjects> Subject { get; set; }
    public DbSet<SubjectTeachers> SubjectTeacher { get; set; }
    public DbSet<Marks> Mark { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Notandi\\RiderProjects\\H25-FK3\\SchoolDB ERD\\school.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many relationship between Subjects and Teachers
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
