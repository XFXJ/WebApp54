using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="水牛",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{Name="斑马",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="猴子",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="红牛",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="火鸡",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="水鸭",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{Name="刘丑",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="火鱼",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="C#",Credits=19,},
            new Course{CourseID=4022,Title="C++",Credits=1,},
            new Course{CourseID=4041,Title="Java",Credits=4,},
            new Course{CourseID=1045,Title="VB",Credits=5,},
            new Course{CourseID=3141,Title="VB+",Credits=6,},
            new Course{CourseID=2021,Title="VB++",Credits=9,},
            new Course{CourseID=2042,Title="WEB",Credits=10,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}