using System.ComponentModel.DataAnnotations;

namespace SchoolDB_ERD;

public class Teacher
{
    [Key]
    public int TeacherId { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public ICollection<SubjectTeacher> SubjectTeachers { get; set; }
}
