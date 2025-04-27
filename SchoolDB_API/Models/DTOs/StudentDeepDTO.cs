namespace SchoolDB_API.Models.DTOs;

using System;
using System.Collections.Generic;

public class StudentDeepDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GroupDTO Group { get; set; }
    public List<MarkDTO> Marks { get; set; }
}

public class GroupDTO
{
    public string Name { get; set; }
}

public class MarkDTO
{
    public SubjectDTO Subject { get; set; }
    public DateTime Date { get; set; }
    public int Score { get; set; }
}

public class SubjectDTO
{
    public string Title { get; set; }
    public List<SubjectTeacherDTO> SubjectTeachers { get; set; }
}

public class SubjectTeacherDTO
{
    public TeacherDTO Teacher { get; set; }
}

public class TeacherDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}