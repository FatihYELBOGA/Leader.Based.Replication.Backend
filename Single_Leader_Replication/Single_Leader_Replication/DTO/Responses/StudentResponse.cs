using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.DTO.Responses
{
    public class StudentResponse
    {
        public StudentResponse(Student student) 
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BornDate = student.BornDate;
            Phone = student.Phone;
            Gender = student.Gender;

            if(student.Department != null)
            {
                Department = new DepartmentResponse(student.Department);
            }

            Courses = new List<StudentCourseResponse>();
            if(student.Courses != null)
            {
                foreach (StudentCourse course in student.Courses)
                {
                    Courses.Add(new StudentCourseResponse(course));
                }
            }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DepartmentResponse Department { get; set; }
        public List<StudentCourseResponse> Courses { get; set; }

    }

}
