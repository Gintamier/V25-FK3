namespace SchoolDB_ERD;

public class SubjectTeachers
{
    public int SubjectId { get; set; }
    public Subjects Subject { get; set; }

    public int TeacherId { get; set; }
    public Teachers Teacher { get; set; }
}

