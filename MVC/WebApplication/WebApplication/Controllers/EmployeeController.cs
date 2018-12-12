using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;


namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工
            var listEmp = empBL.GetEmpoleesList();

            var listEmpVm = new List<EmployeeViewModel>();
            foreach(var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.Salary = item.Salary.ToString("c");
                if(item.Salary>10000)
                {
                    empVmObj.SalaryGrade = "土豪";
                }
                else
                {
                    empVmObj.SalaryGrade = "屌丝";
                }
                listEmpVm.Add(empVmObj);
            }

            empListModel.Employees = listEmpVm;

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
            
            empListModel.UserName = "管理员";
            empListModel.Greeting = greeting;
            return View(empListModel);
        }
    }
}