namespace Single_Leader_Replication.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone {  get; set; }
        public string Gender { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<StudentCourse>? Courses {  get; set; } 

    }
}
