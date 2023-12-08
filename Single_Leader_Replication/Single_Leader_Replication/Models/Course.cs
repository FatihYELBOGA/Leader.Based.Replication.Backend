namespace Single_Leader_Replication.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Code { get; set; }
        public string Instructor {  get; set; }
        public List<StudentCourse>? Students { get; set; }

    }
}
