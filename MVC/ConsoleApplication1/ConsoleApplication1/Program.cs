using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BussinessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();

            AddPost();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
           //显示指定博客的帖子列表
             DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子  


            //显示指定博客的帖子列表

        }

        static int GetBlogId() {
            //提示用户输入博客ID
            Console.WriteLine("请输入id");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            //返回id          
            return id;
        }

        static void DisplatPosts(int blogId) {
            Console.WriteLine(blogId+"的帖子列表");
            //根据博客id获取博客

            //根据博客导航属性，获取所有该博客的帖子
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
        }



        //增加--交互

        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            bbl.Add(blog);
        }

        //显示全部博客
        static void QueryBlog()
        {
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        static void Delete()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }


    }
}
