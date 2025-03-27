namespace SchoolDB_ERD;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    public int GroupId { get; set; }
    public SchoolGroup Group { get; set; }

    public ICollection<Mark> Marks { get; set; }
}