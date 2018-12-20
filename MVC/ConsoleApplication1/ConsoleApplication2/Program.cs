using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db=new SchoolEntities())
            {
              db.Departments.ToList();
            }
        }
    }

    public class SchoolEntities : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }

    public class Department
    {
        // Primary key
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        // Primary key
        public int CourseID { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }

        // Foreign key
        public int DepartmentID { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; }
    }

    public partial class OnlineCourse : Course
    {
        public string URL { get; set; }
    }

    public partial class OnsiteCourse : Course
    {
        public string Location { get; set; }
        public string Days { get; set; }
        public System.DateTime Time { get; set; }
    }




}
