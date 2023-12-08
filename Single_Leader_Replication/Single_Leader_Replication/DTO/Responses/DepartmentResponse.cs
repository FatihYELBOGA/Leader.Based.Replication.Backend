using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.DTO.Responses
{
    public class DepartmentResponse
    {
        public DepartmentResponse(Department department) 
        {
            Id = department.Id;
            DepartmentName = department.DepartmentName;
            FacultyName = department.FacultyName;
            DepartmentHead = department.DepartmentHead;
            Email = department.Email;
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentHead { get; set; }
        public string Email { get; set; }

    }

}
