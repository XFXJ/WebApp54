using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

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
            c.Address = "柳州职业技术学院";
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
            ViewData["greeting"] = greeting;
            Employee emp = new Employee();
            emp.Name = "刘帅";
            emp.Salary = 2000;
            ViewData["Employee"] = emp;
            return View("MyView");
        }
    }

}