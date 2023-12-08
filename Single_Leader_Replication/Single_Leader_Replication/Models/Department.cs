namespace Single_Leader_Replication.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentHead {  get; set; }
        public string Email { get; set; }
        public List<Student>? Students { get; set; }

    }
}
