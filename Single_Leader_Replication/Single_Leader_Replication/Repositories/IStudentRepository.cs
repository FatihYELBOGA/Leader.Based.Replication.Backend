using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudent();
        public Student GetStudentById(int id);
        public Student AddStudent(Student newStudent);
        public Student UpdateStudent(Student currentStudent);
        public Student UpdateGrade(StudentCourse currentStudentCourse);

    }

}
