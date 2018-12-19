using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication1.Models;
using ConsoleApplication1.DataAccesslayer;

namespace ConsoleApplication1.StudentLayer
{
    class StudentBusinessLayer
    {
        public void Add(Class classa)
        {
            using (var sc = new StudentContext())
            {
                sc.Classs.Add(classa);
                sc.SaveChanges();
            }
        }
        public List<Class> Query()
        {
            using (var sc = new StudentContext())
            {
                var query = from b in sc.Classs orderby b.ClassName select b;
                return query.ToList();
            }
        }
        public Class Query(int id)
        {
            using (var sc = new StudentContext())
            {
                return sc.Classs.Find(id);
            }
        }
        public void Update(Class classs)
        {
            using (var sc = new StudentContext())
            {
                sc.Entry(classs).State = EntityState.Modified;
                sc.SaveChanges();
            }
        }
        public void Delete(Class classs)
        {
            using (var sc = new StudentContext())
            {
                sc.Entry(classs).State = EntityState.Deleted;
                sc.SaveChanges();
            }
        }
    }
}
