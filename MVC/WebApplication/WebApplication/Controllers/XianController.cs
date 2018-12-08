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
            ViewBag.greeting = greeting;
            Customer cus = new Customer();
            cus.CustomerName = "猴子";
            cus.Address = 2000;
            ViewBag.Customer = cus;
            return View("Gettest", cus);
        }
    }
}