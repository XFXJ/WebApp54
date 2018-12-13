using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class InformationListViewModel
    {
        public string UserName { get; set; }
        public List<InformationViewModel> Informat { get; set; }
        public string Greeting { get; set; }
    }
}