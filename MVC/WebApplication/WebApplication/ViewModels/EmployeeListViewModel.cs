using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class EmployeeListViewModel
    {
        public string UserName { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public string Greeting { get; set; }
    }
}