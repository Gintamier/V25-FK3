using Microsoft.AspNetCore.Mvc;
using SchoolDB_API.Interfaces;
using System.Threading.Tasks;
using SchoolDB_API.Models;
using SchoolDB_API.Models.DTOs;

namespace SchoolDB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost("deep")]
        public async Task<IActionResult> CreateDeep(StudentDeepDTO dto)
        {
            var group = new SchoolGroup
            {
                Name = dto.Group.Name,
                Students = new List<Student>()
            };

            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Group = group,
                Marks = new List<Mark>()
            };

            foreach (var markDto in dto.Marks)
            {
                var subject = new Subject
                {
                    Title = markDto.Subject.Title,
                    SubjectTeachers = new List<SubjectTeacher>()
                };

                foreach (var stDto in markDto.Subject.SubjectTeachers)
                {
                    var teacher = new Teacher
                    {
                        FirstName = stDto.Teacher.FirstName,
                        LastName = stDto.Teacher.LastName
                    };

                    var subjectTeacher = new SubjectTeacher
                    {
                        Subject = subject,
                        Teacher = teacher
                    };

                    subject.SubjectTeachers.Add(subjectTeacher);
                }

                var mark = new Mark
                {
                    Student = student,
                    Subject = subject,
                    Date = markDto.Date,
                    Score = markDto.Score
                };

                student.Marks.Add(mark);
            }

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student updatedStudent)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.GroupId = updatedStudent.GroupId;

            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
