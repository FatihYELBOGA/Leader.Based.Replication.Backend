namespace Single_Leader_Replication.DTO.Requests
{
    public class StudentCourseRequest
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }

    }

}
