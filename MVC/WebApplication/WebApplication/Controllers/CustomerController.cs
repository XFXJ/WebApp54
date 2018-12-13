using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
       
        public ActionResult Index()
        {
            InformationListViewModel infListModel = new InformationListViewModel();
            //实例化员工信息业务层
            CuBusinessLayer infCU = new CuBusinessLayer();
            //员工
            var listInf = infCU.GetEmpoleesList();

            var listInfVm = new List<InformationViewModel>();
            foreach (var item in listInf)
            {
                InformationViewModel infVmObj = new InformationViewModel();
                infVmObj.InformationName = item.Name;
                infVmObj.Salary = item.State;
              
                listInfVm.Add(infVmObj);
            }

            infListModel.Informat = listInfVm;

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

            infListModel.UserName = "客户";
            infListModel.Greeting = greeting;
            return View(infListModel);
        }
    }
}