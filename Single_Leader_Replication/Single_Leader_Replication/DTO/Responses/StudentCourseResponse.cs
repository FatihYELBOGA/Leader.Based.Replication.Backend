using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.DTO.Responses
{
    public class StudentCourseResponse
    {
        public StudentCourseResponse(StudentCourse course)
        {
            Id = course.Id;
            CourseName = course.Course.CourseName;
            Code = course.Course.Code;
            Instructor = course.Course.Instructor;
            Grade = course.Grade;
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Code { get; set; }
        public string Instructor { get; set; }
        public string Grade { get; set; }

    }

}
