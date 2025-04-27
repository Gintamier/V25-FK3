using System.ComponentModel.DataAnnotations;

namespace SchoolDB_API.Models;

public class Teachers
{
    [Key]
    public int TeacherId { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public ICollection<SubjectTeachers> SubjectTeachers { get; set; }
}
