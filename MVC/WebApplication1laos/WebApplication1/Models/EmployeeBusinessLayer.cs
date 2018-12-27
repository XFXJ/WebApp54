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
        //增加方法
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        //删除方法
        public void Delete(int id)
        {
            using (SalesERPDAL sales = new SalesERPDAL())
            {
                Employee emp = sales.Employees.Find(id);
                sales.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                sales.SaveChanges();
            }
        }

        //查询方法
        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                return emp;
            }
        }
        //更新方法
        public void Update(Employee emp)
        {
            using (var db = new SalesERPDAL())
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
    }