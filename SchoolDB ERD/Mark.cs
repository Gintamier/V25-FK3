namespace SchoolDB_ERD;

using System;
using System.ComponentModel.DataAnnotations;

public class Mark
{
    public int MarkId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public DateTime Date { get; set; }
    public int Score { get; set; }
}

