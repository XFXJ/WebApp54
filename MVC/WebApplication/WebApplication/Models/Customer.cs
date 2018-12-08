using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Customer
    {
        public string CustomerName
        {
            get;
            set;
        }
        public int Address
        {
            get;
            set;
        }
        //public override string ToString()
        //{
        //    return this.CustomerName + "-" + this.Address;
        //}

    }
}