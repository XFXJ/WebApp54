using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CuBusinessLayer
    {
        public List<Information> GetEmpoleesList()
        {
            var list = new List<Information>();
            Information inf = new Information();
            inf.Name = "张三";
            inf.State= "非洲";

            list.Add(inf);

            inf = new Information();
            inf.Name = "李四";
            inf.State = "意大利";

            list.Add(inf);

            inf = new Information();
            inf.Name = "王五";
            inf.State = "阿根廷";

            list.Add(inf);
            return list;
        }
    }
}