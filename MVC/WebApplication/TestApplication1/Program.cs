using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobileList = new List<Mobile>();

            Mobile mo = new Mobile();
            mo.Brand = "华为";
            mo.Production = "中国";
            mo.Price = 3000;
            mo.Quantity = 1;
            

            mobileList.Add(mo);

            mo = new Mobile();
            mo.Brand = "三星";
            mo.Production = "韩国";
            mo.Price = 4000;
            mo.Quantity = 2;

            mobileList.Add(mo);

            mo = new Mobile();
            mo.Brand = "努比亚";
            mo.Production = "中国";
            mo.Price = 2500;
            mo.Quantity = 3;

            mobileList.Add(mo);

            foreach(var item in mobileList)
            {
                Console.WriteLine("brand:{0},price:{1},quantity:{2}，production:{3}", item.Brand, item.Price,item.Quantity,item.Production);
            }
            Console.ReadKey();
          
        }
    }
}
