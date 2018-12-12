using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmpoleesList()
        {
            var list = new List<Employee>();
            Employee emp = new Employee();
            emp.Name = "张三";
            emp.Salary = 10000;

            list.Add(emp);

            emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 100000;

            list.Add(emp);

            emp = new Employee();
            emp.Name = "王五";
            emp.Salary = 100000;

            list.Add(emp);
            return list;
        }
    }
}