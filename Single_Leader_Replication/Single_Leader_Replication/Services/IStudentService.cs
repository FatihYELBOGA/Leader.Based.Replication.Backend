using Single_Leader_Replication.DTO.Requests;
using Single_Leader_Replication.DTO.Responses;

namespace Single_Leader_Replication.Services
{
    public interface IStudentService
    {
        public List<StudentResponse> GetAllStudent();
        public StudentResponse GetStudentById(int id);
        public StudentResponse AddStudent(StudentRequest newStudent);
        public StudentResponse UpdateStudent(int id, StudentRequest currentStudent);
        public StudentResponse UpdateGrade(StudentCourseRequest currentStudentCourse);

    }

}
