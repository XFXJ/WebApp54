using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;


namespace WebApplication.Controllers
{
    public class HaloController : Controller
    {
       
        public ActionResult GetView()
        {
            Customer cu = new Customer();
            cu.CustomerName = "恶爷";
            cu.Address = "s";

            Employee emp =new Employee();
            emp.Name = "恶爷";
            emp.Salary = 10000;

            EmCu emcu = new EmCu();
            emcu.CustomerInfo = cu;
            emcu.EmployeeInfo = emp;


            return View("",emcu);
        }
    }
}