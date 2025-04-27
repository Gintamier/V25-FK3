using System.ComponentModel.DataAnnotations;

namespace SchoolDB_API.Models;

public class SchoolGroup
{
    [Key]
    public int GroupId { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }
}
