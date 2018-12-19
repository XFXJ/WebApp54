using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.StudentLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            createBlog();
            QueryBlog();
            Update();
            QueryBlog();
            Delete();
            Console.WriteLine("随便退出");
            Console.ReadKey();
        }
        static void createBlog()
        {
            Console.WriteLine("输入班级名称");
            string name = Console.ReadLine();
            Class classa = new Class();
            classa.ClassName= name;
            StudentBusinessLayer sss = new StudentBusinessLayer();
            sss.Add(classa);
        }
        static void QueryBlog()
        {
            StudentBusinessLayer st = new StudentBusinessLayer();
            var classs = st.Query();
            foreach (var itme in classs)
            {
                Console.WriteLine(itme.Classid + "" + itme.ClassName);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            StudentBusinessLayer ss = new StudentBusinessLayer();
            Class clas = ss.Query(id);
            Console.WriteLine("请输入新名");
            string name = Console.ReadLine();
            clas.ClassName = name;
            ss.Update(clas);
        }
        static void Delete()
        {
            StudentBusinessLayer ss = new StudentBusinessLayer();
            Console.Write("请输入id");
            int id = int.Parse(Console.ReadLine());
            Class cals = ss.Query(id);
            ss.Delete(cals);
        }
    }
}
