using Microsoft.EntityFrameworkCore;
using Single_Leader_Replication.Configurations;
using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly LeaderSchoolManagement _leaderDatabase;
        private readonly FollowerSchoolManagement _followerDatabase;

        public StudentRepository(LeaderSchoolManagement leaderDatabase, FollowerSchoolManagement followerDatabase) 
        {
            _leaderDatabase = leaderDatabase;
            _followerDatabase = followerDatabase;
        }

        public List<Student> GetAllStudent()
        {
            return _followerDatabase.Students
                .Include(s => s.Department)
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .ToList(); 
        }

        public Student GetStudentById(int id)
        {
            return _followerDatabase.Students
                .Where(s => s.Id == id)
                .Include(s => s.Department)
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefault();
        }

        public Student AddStudent(Student newStudent)
        {
            _leaderDatabase.Students.Add(newStudent);
            _leaderDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\leader_database_log.txt", true))
            {
                outputFile.WriteLine("INSERT INTO students VALUES ('" +
                    newStudent.FirstName + "', '" +
                    newStudent.LastName + "', '" +
                    newStudent.BornDate + "', '" +
                    newStudent.Gender + "', '" +
                    newStudent.Phone + "', " +
                    newStudent.DepartmentId + ")");
            }

            newStudent.Id = 0;
            _followerDatabase.Students.Add(newStudent);
            _followerDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\follower_database_log.txt", true))
            {
                outputFile.WriteLine("INSERT INTO students VALUES ('" + 
                    newStudent.FirstName + "', '" + 
                    newStudent.LastName + "', '" + 
                    newStudent.BornDate + "', '" + 
                    newStudent.Gender + "', '" + 
                    newStudent.Phone + "', " + 
                    newStudent.DepartmentId + ")");
            }

            return GetStudentById(newStudent.Id);
        }

        public Student UpdateStudent(Student currentStudent)
        {
            Student updatedStudent = _leaderDatabase.Students.Update(currentStudent).Entity;
            _leaderDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\leader_database_log.txt", true))
            {
                outputFile.WriteLine("UPDATE students SET FirstName = '" + currentStudent.FirstName +
                    "' , LastName = '" + currentStudent.LastName +
                    "' , BornDate = '" + currentStudent.BornDate +
                    "' , Gender = '" + currentStudent.Gender + 
                    "' , Phone = '" + currentStudent.Phone + 
                    "' , DepartmentId = " + currentStudent.DepartmentId + 
                    " WHERE Id = " + currentStudent.Id);
            }

            _followerDatabase.Students.Update(currentStudent);
            _followerDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\follower_database_log.txt", true))
            {
                outputFile.WriteLine("UPDATE students SET FirstName = '" + currentStudent.FirstName +
                    "', LastName = '" + currentStudent.LastName +
                    "', BornDate = '" + currentStudent.BornDate +
                    "', Gender = '" + currentStudent.Gender +
                    "', Phone = '" + currentStudent.Phone +
                    "', DepartmentId = " + currentStudent.DepartmentId +
                    " WHERE Id = " + currentStudent.Id);
            }

            return GetStudentById(updatedStudent.Id);
        }

        public Student UpdateGrade(StudentCourse currentStudentCourse)
        {
            _leaderDatabase.StudentCourses.Update(currentStudentCourse);
            _leaderDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\leader_database_log.txt", true))
            {
                outputFile.WriteLine("UPDATE studentcourses SET Grade = '" + currentStudentCourse.Grade + 
                    "', StudentId = " + currentStudentCourse.StudentId +
                    "', CourseId = " + currentStudentCourse.CourseId +
                    " WHERE Id = " + currentStudentCourse.Id);
            }

            _followerDatabase.StudentCourses.Update(currentStudentCourse);
            _followerDatabase.SaveChanges();
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\Fatih YELBOĞA\\Documents\\Logs\\follower_database_log.txt", true))
            {
                outputFile.WriteLine("UPDATE studentcourses SET Grade = '" + currentStudentCourse.Grade +
                    "', StudentId = " + currentStudentCourse.StudentId +
                    "', CourseId = " + currentStudentCourse.CourseId +
                    " WHERE Id = " + currentStudentCourse.Id);
            }

            return GetStudentById((int) currentStudentCourse.StudentId);
        }

    }

}
