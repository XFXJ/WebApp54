using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using WebApplication.DataAccessLayer;


namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //获取将处理过的数据列表
            empListModel.Employees = getEmpVmList();
            //获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);

        }

        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployees();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.Salary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.SalaryGrade = "土豪";
                }
                else
                {
                    empVmObj.SalaryGrade = "屌丝";
                }

                listEmpVm.Add(empVmObj);
            }
            return listEmpVm;
        }
        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }
        string getUserName()
        {
            return "Admin";
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        //public ActionResult SaveEmployee(Employee e)
        //{
        //    SalesERPOLDAL salesDal = new SalesERPOLDAL();
        //}
        public string SaveEmployee(Employee e)
        {
            return "姓名：" + e.Name + "工资：" + e.Salary;
        }
    }

}