namespace SchoolDB_API.Models;

public class SubjectTeachers
{
    public int SubjectId { get; set; }
    public Subjects Subject { get; set; }

    public int TeacherId { get; set; }
    public Teachers Teacher { get; set; }
}

