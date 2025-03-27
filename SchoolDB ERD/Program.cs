using SchoolDB_ERD;

class Program
{
    static void Main()
    {
        using var context = new SchoolContext();
        context.Database.EnsureCreated();

        // Add a group
        var group = new SchoolGroup { Name = "3. Önn" };
        context.Group.Add(group);
        context.SaveChanges();

        // Add a student
        var student = new Students
        {
            FirstName = "Ólafur Karl",
            LastName = "Karlsson",
            GroupId = group.GroupId
        };
        context.Student.Add(student);
        context.SaveChanges();

        // Add a teacher
        var teacher = new Teachers
        {
            FirstName = "Hjörtur",
            LastName = "Pálmi"
        };
        context.Teacher.Add(teacher);
        context.SaveChanges();

        // Add a subject
        var subject = new Subjects
        {
            Title = "Backend Programming"
        };
        context.Subject.Add(subject);
        context.SaveChanges();

        // Connect teacher to subject
        var subjectTeacher = new SubjectTeachers
        {
            SubjectId = subject.SubjectId,
            TeacherId = teacher.TeacherId
        };
        context.SubjectTeacher.Add(subjectTeacher);
        context.SaveChanges();

        // Add a mark
        var mark = new Marks
        {
            StudentId = student.StudentId,
            SubjectId = subject.SubjectId,
            Date = DateTime.Now,
            Score = 95
        };
        context.Mark.Add(mark);
        context.SaveChanges();

        // Display everything
        Console.WriteLine("=== Sample Data ===");
        foreach (var s in context.Student)
        {
            Console.WriteLine($"Student: {s.FirstName} {s.LastName}");
        }

        foreach (var t in context.Teacher)
        {
            Console.WriteLine($"Teacher: {t.FirstName} {t.LastName}");
        }

        foreach (var sub in context.Subject)
        {
            Console.WriteLine($"Subject: {sub.Title}");
        }

        foreach (var m in context.Mark)
        {
            Console.WriteLine($"Mark: {m.Score}, Date: {m.Date}");
        }
    }
}
