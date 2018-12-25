using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numList = { 10, 20, 30, 40, 11, 21, 31, 41 };
            ////var query = from c in numList
            ////            where c % 2 == 0
            ////            select c;
            //var query1 = from c in numList where (c % 2 == 0) && (c > 20) select c;
            //var query2 = numList.Where(c => c % 2 == 0).OrderBy(c => c);
            //foreach(var item in query2)
            //{
            //    Console.Write(item.ToString() + "");
            //}
            //Console.ReadKey();

            string[] nsmes = { "abc", "aaa", "dbe", "bade", "xyz657" };
            var nusm = from n in nsmes
                       where n.Contains("a")
                       select n;
            foreach (var item in nusm)
            {
                Console.WriteLine(item.ToString() + "");
            }
            Console.ReadKey();
        }
    }
}
