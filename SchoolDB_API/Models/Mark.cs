using System;
using System.ComponentModel.DataAnnotations;
namespace SchoolDB_API.Models;


public class Mark
{
    [Key]
    public int MarkId { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public DateTime Date { get; set; }

    public int Score { get; set; }
}