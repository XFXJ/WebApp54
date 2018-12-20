using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BlogBusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;


namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();
            //Update();
            //QueryBlog();
            //Delete();
            AddPost();
            Console.WriteLine("随便退出");
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
        static int GetBlogId()
        {
            //提示用户输入博客ID
            Console.WriteLine("请输入id");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            //返回ID
            return id;
        }
        static void DisplatPosts(int blogId)
        {
            //Console.WriteLine("请输入id");
            //BlogBusinessLayera bll = new BlogBusinessLayera();
            //Blog blog = bll.Query(blogId);
            //Console.WriteLine(blog.Name); 

            Console.WriteLine(blogId + "的帖子列表");
            List<Post> list = null;
            //根据博客id获取博客
            using (var db = new BloggingContext())
            {
                Blog blog= db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts;
            }
            //遍历所有帖子，显示帖子标题
           foreach(var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title);
            }

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
