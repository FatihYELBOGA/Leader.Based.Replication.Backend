using Microsoft.EntityFrameworkCore;
using Single_Leader_Replication.Models;

namespace Single_Leader_Replication.Configurations
{
    public class FollowerSchoolManagement : DbContext
    {
        public FollowerSchoolManagement(DbContextOptions<FollowerSchoolManagement> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // students table relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // student courses table relationships
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void Seed(FollowerSchoolManagement followerDatabase)
        {
            if (followerDatabase.Database.GetPendingMigrations().Count() == 0)
            {
                if (followerDatabase.Students.Count() == 0)
                {
                    followerDatabase.Departments.AddRange(departments);
                    followerDatabase.Students.AddRange(students);
                    followerDatabase.Courses.AddRange(courses);
                    followerDatabase.StudentCourses.AddRange(studentCourses);

                    followerDatabase.SaveChanges();
                }
            }
        }

        private static Department[] departments = new Department[]
        {
            new Department {
                DepartmentName = "Computer Engineering",
                FacultyName = "Engineering Faculty",
                DepartmentHead = "Fatih YELBOĞA",
                Email = "iztech_computer_engineering@gmail.com"
            },
            new Department {
                DepartmentName = "Pyhsics",
                FacultyName = "Science Faculty",
                DepartmentHead = "Enes DEMIREL",
                Email = "iztech_physics@gmail.com"
            },
            new Department {
                DepartmentName = "Photonic",
                DepartmentHead = "Osman ALTUNAY",
                FacultyName = "Science Faculty",
                Email = "iztech_photonic@gmail.com"
            }
        };

        private static Student[] students = new Student[]
        {
            new Student {
                FirstName = "Berkay",
                LastName = "BAYRAK",
                BornDate = new DateTime(2000,01,05),
                Phone = "+90-550-045-60-65",
                Gender = "MALE",
                Department = departments[0]
            },
            new Student {
                FirstName = "Muhammed Emin",
                LastName = "KILINCLI",
                BornDate = new DateTime(2001,03,20),
                Phone = "+90-541-950-05-05",
                Gender = "MALE",
                Department = departments[0]
            },
            new Student {
                FirstName = "Merve Nur",
                LastName = "OZAN",
                BornDate = new DateTime(2002,06,10),
                Phone = "+90-536-045-00-08",
                Gender = "FEMALE",
                Department = departments[1]
            },
            new Student {
                FirstName = "Celal",
                LastName = "BIYIKLI",
                BornDate = new DateTime(1999,09,15),
                Phone = "+90-545-950-60-65",
                Gender = "MALE",
                Department = departments[1]
            },
            new Student {
                FirstName = "Arif",
                LastName = "SONMEZ",
                BornDate = new DateTime(1998,12,25),
                Phone = "+90-536-080-60-65",
                Gender = "MALE",
                Department = departments[2]
            },
            new Student {
                FirstName = "Burak",
                LastName = "KURT",
                BornDate = new DateTime(1997,06,15),
                Phone = "+90-542-064-44-00",
                Gender = "MALE",
                Department = departments[2]
            },
        };

        private static Course[] courses = new Course[]
        {
            new Course {
                CourseName = "Data Intensive Systems",
                Code = "CENG465",
                Instructor = "Damla OGUZ"
            },
            new Course {
                CourseName = "Introduction to Physics",
                Code = "CENG465",
                Instructor = "Ahmet YILMAZ"
            },
            new Course {
                CourseName = "History of Photonic",
                Code = "CENG465",
                Instructor = "Yunus KAPLAN"
            }
        };

        private static StudentCourse[] studentCourses = new StudentCourse[]
        {
            new StudentCourse
            {
                Student = students[0],
                Course = courses[0],
                Grade = "AA"
            },
            new StudentCourse
            {
                Student = students[1],
                Course = courses[0],
                Grade = "BA"
            },
            new StudentCourse
            {
                Student = students[2],
                Course = courses[1],
                Grade = "AA"
            },
            new StudentCourse
            {
                Student = students[3],
                Course = courses[1],
                Grade = "CC"
            },
            new StudentCourse
            {
                Student = students[4],
                Course = courses[2],
                Grade = "DD"
            },
            new StudentCourse
            {
                Student = students[5],
                Course = courses[2],
                Grade = "BA"
            }
        };

    }
}
