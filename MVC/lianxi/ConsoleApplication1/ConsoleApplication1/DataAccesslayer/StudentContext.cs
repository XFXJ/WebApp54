using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.DataAccesslayer
{
    class StudentContext : DbContext
    {
            public DbSet<Student> Students { get; set; }
            public DbSet<Class> Classs { get; set; } 
    }
}
