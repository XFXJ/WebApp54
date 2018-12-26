using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;


namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
              
                var list = dal.Employees.ToList();
                return list;
            }   
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        public void Delete(int id)
        {
            using (SalesERPDAL sales = new SalesERPDAL())
            {
                Employee emp = sales.Employees.Find(id);
                sales.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                sales.SaveChanges();
            }
            
        }
    }
}