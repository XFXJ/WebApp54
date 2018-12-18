using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BlogBusinessLayer;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            QueryBlog();
            Update();
            QueryBlog();
            Delete();
            Console.WriteLine("随便退出");
            Console.ReadKey();
        }
        static void createBlog()
        {
            Console.WriteLine("输入博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
           BlogBusinessLayera bll = new BlogBusinessLayera();
            bll.Add(blog);
        }
        static void QueryBlog()
        {
            BlogBusinessLayera bbl = new BlogBusinessLayera();
            var blogs = bbl.Query();
            foreach(var itme in blogs)
            {
                Console.WriteLine(itme.BlogId + ""+itme.Name);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayera bbl = new BlogBusinessLayera();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void Delete()
        {
            BlogBusinessLayera bbl = new BlogBusinessLayera();
            Console.Write("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
