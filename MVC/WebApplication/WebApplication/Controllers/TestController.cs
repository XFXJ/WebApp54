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
    }
}