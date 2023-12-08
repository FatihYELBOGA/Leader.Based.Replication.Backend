using Microsoft.AspNetCore.Mvc;
using Single_Leader_Replication.DTO.Requests;
using Single_Leader_Replication.DTO.Responses;
using Single_Leader_Replication.Services;

namespace Single_Leader_Replication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/students")]
        public List<StudentResponse> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }

        [HttpGet("/students/id")]
        public StudentResponse GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPost("/students")]
        public StudentResponse AddStudent([FromForm] StudentRequest studentRequest)
        {
            return _studentService.AddStudent(studentRequest);
        }

        [HttpPut("/students/{id}")]
        public StudentResponse UpdateStudent(int id, [FromForm] StudentRequest studentRequest)
        {
            return _studentService.UpdateStudent(id, studentRequest);
        }

        [HttpPost("/students/grades")]
        public StudentResponse UpdateGrade([FromForm] StudentCourseRequest studentCourseRequest)
        {
            return _studentService.UpdateGrade(studentCourseRequest);
        }

    }

}
