using System;
using System.Linq;
using SchoolDB_ERD;

class Program
{
    static void Main()
    {
        using (var context = new SchoolContext())
        {
            // Check if database and tables are created
            context.Database.EnsureCreated();

            Console.WriteLine("Tables created:");
            Console.WriteLine($"Students: {context.Student.Count()} records");
            Console.WriteLine($"Groups: {context.Group.Count()} records");
            Console.WriteLine($"Teachers: {context.Teacher.Count()} records");
            Console.WriteLine($"Subjects: {context.Subject.Count()} records");
            Console.WriteLine($"Marks: {context.Mark.Count()} records");
            Console.WriteLine($"SubjectTeachers: {context.SubjectTeacher.Count()} records");
        }
    }
}