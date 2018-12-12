using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "你是谁！";
        }
        public Customer getGustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "刘帅";
            //c.Address = "柳州职业技术学院";
            return c;
        }
        public ActionResult GetView()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int h = dt.Hour;
            if (h < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "中午好";
            }
            //ViewData["greeting"] = greeting;
            ViewBag.greeting = greeting;
            Employee emp = new Employee();
            emp.Name = "刘帅";
            emp.Salary = 2000;

            EmployeeViewModel vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = emp.Name;
            vmEmp.Salary = emp.Salary.ToString("c");
            if(emp.Salary>1000)
            {
                vmEmp.SalaryGrade = "老板";
            }
            else
            {
                vmEmp.SalaryGrade = "搬砖";
            }
            //ViewData["Employee"] = emp;
            //ViewBag.Employee = emp;
            //vmEmp.UserName = "管理员";
            //vmEmp.Greeting = "早上好";
            return View("MyView",vmEmp);
        }
    }

}