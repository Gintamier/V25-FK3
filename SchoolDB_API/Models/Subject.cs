using System.ComponentModel.DataAnnotations;

namespace SchoolDB_API.Models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    
    [Required]
    public string Title { get; set; }

    public ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    public ICollection<Mark> Marks { get; set; }
}
