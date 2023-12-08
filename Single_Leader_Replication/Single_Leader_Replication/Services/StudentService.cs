using Single_Leader_Replication.DTO.Requests;
using Single_Leader_Replication.DTO.Responses;
using Single_Leader_Replication.Models;
using Single_Leader_Replication.Repositories;

namespace Single_Leader_Replication.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentResponse> GetAllStudent()
        {
            List<StudentResponse> studentResponses = new List<StudentResponse>();
            foreach (var student in _studentRepository.GetAllStudent())
            {
                studentResponses.Add(new StudentResponse(student));
            }

            return studentResponses;
        }

        public StudentResponse GetStudentById(int id)
        {
            return new StudentResponse(_studentRepository.GetStudentById(id));
        }

        public StudentResponse AddStudent(StudentRequest newStudent)
        {
            Student addedStudent  = new Student();
            addedStudent.FirstName = newStudent.FirstName;
            addedStudent.LastName = newStudent.LastName;

            string[] date = newStudent.BornDate.Split("-");
            addedStudent.BornDate = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));

            addedStudent.Phone = newStudent.Phone;
            addedStudent.Gender = newStudent.Gender;
            addedStudent.DepartmentId = newStudent.DepartmentId;

            return new StudentResponse(_studentRepository.AddStudent(addedStudent));
        }

        public StudentResponse UpdateStudent(int id, StudentRequest currentStudent)
        {
            Student foundStudent = _studentRepository.GetStudentById(id);
            foundStudent.Id = id;
            foundStudent.FirstName = currentStudent.FirstName;
            foundStudent.LastName = currentStudent.LastName; 
            
            string[] date = currentStudent.BornDate.Split("-");
            foundStudent.BornDate = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));

            foundStudent.Phone = currentStudent.Phone;
            foundStudent.Gender = currentStudent.Gender;
            foundStudent.DepartmentId = currentStudent.DepartmentId;

            return new StudentResponse(_studentRepository.UpdateStudent(foundStudent));
        }

        public StudentResponse UpdateGrade(StudentCourseRequest currentStudentCourse)
        {
            StudentCourse foundStudentCourse = new StudentCourse();
            foundStudentCourse.Id = currentStudentCourse.Id;
            foundStudentCourse.StudentId = currentStudentCourse.StudentId;
            foundStudentCourse.CourseId = currentStudentCourse.CourseId;
            foundStudentCourse.Grade = currentStudentCourse.Grade;

            return new StudentResponse(_studentRepository.UpdateGrade(foundStudentCourse));
        }

    }

}
