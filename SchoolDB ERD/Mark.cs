using System;
using System.ComponentModel.DataAnnotations;
using SchoolDB_ERD;

public class Marks
{
    [Key]
    public int MarkId { get; set; }

    public int StudentId { get; set; }
    public Students Student { get; set; }

    public int SubjectId { get; set; }
    public Subjects Subject { get; set; }

    public DateTime Date { get; set; }

    public int Score { get; set; }
}