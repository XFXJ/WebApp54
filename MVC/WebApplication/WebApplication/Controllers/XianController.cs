using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class XianController : Controller
    {
       
        public ActionResult Gettest()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int h = dt.Hour;
            if (h < 12)
            {
                greeting = "早上好!";
            }
            else
            {
                greeting = "中午好!";
            }
            //ViewData["greeting"] = greeting;
            ViewBag.greeting = greeting;
            Employee emp = new Employee();
            emp.Name = "刘帅";
            emp.Salary = 2000;
            ViewData["Employee"] = emp;
            ViewData["Customer"] = emp;
            //ViewBag.Employee = emp;
            //return View("MyView", emp);
            //ViewBag.greeting = greeting;
            Customer cus = new Customer();
            cus.CustomerName = "猴子";
            cus.Address = "非洲";
            ViewBag.Customer = cus;
            return View("Gettest");
        }
    }
}