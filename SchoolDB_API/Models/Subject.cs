using System.ComponentModel.DataAnnotations;

namespace SchoolDB_API.Models;

public class Subjects
{
    [Key]
    public int SubjectId { get; set; }
    
    [Required]
    public string Title { get; set; }

    public ICollection<SubjectTeachers> SubjectTeachers { get; set; }
    public ICollection<Mark> Marks { get; set; }
}
