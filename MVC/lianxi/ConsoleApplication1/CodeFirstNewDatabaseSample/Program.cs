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
            //QueryBlog();
            //用户选择某个博客（id）
            //int blogId = GetBlogId();
            ////显示指定博客的帖子列表
            //DisplayPosts(blogId);
            ////根据指定到博客信息创建新帖子
            //PostById(blogId);
            ////显示指定博客的帖子列表
            //DisplayPosts(blogId);
            ////修改帖子
            //UpdatePosts();
            ////删除帖子
            //DeletePosts();
            BlogGather();
        }
        static void BlogGather()
        {
            //显示所有博客
            QueryBlog();
            Console.WriteLine("1:退出--   --2:新增博客--   --3:更改博客--  --4:删除博客--  --5:操作帖子--");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                return;
            }

            else if (i == 2)
            {
                createBlog();
                QueryBlog();
                Console.Clear();
                BlogGather();
            }
            else if (i == 3)
            {
                Update();
                QueryBlog();
                Console.Clear();
                BlogGather();
            }
            else if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                BlogGather();
            }
            else if (i == 5)
            {
                //int blogId = GetBlogId();
                ////显示指定博客的帖子列表
                //DisplayPosts(blogId);
                Console.WriteLine("1:退出--   --2:新增博客--   --3:更改博客--  --4:删除博客--  --5:操作帖子--");
                Console.WriteLine("请输入操作指令");
                int s = int.Parse(Console.ReadLine());
                if (s == 1)
                {
                    return;
                }

                else if (s == 2)
                {
                   
                    QueryBlog();
                    Console.Clear();
                    BlogGather();
                }
                else if (s == 3)
                {
                    Update();
                    QueryBlog();
                    Console.Clear();
                    BlogGather();
                }
                else if (s == 4)
                {
                    Delete();
                    QueryBlog();
                    Console.Clear();
                    BlogGather();
                }
                else if (s == 5)
                {
                    int blogId = GetBlogId();
                    //显示指定博客的帖子列表
                    DisplayPosts(blogId);
                }
            }
            else
            {
                Console.WriteLine("无效字符");
            }
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
        static void DisplayPosts(int blogId)
        {
            {
                BlogBusinessLayera bbl = new BlogBusinessLayera();
                Blog blog = bbl.Query(blogId);

                List<Post> postList = bbl.PostQuery(blogId);
                foreach (var item in postList)
                {
                    Console.WriteLine("--博客ID:{0}--  ---帖子题目：{1}--  ---帖子内容:{2}--  ---帖子ID:{3}--", item.BlogId, item.Title, item.Content, item.PostId);
                }
            }
        }
        static void PostById(int blogId)
        {
            Console.WriteLine("请输入id");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("输入一个帖子名称");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一个帖子内容");
            string content = Console.ReadLine();

            Post post = new Post();
            post.BlogId = blogId;
            post.Title = title;
            post.Content = content;

            BlogBusinessLayera bll = new BlogBusinessLayera();
            bll.PostAdd(post);
        }
        //修改
        static void UpdatePosts()
        {
            QueryBlog();


            BlogBusinessLayera bbl = new BlogBusinessLayera();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入要修改的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            Console.WriteLine("请输入新题目");
            string newTitle = Console.ReadLine();
            post.Title = newTitle;
            Console.WriteLine("请输入新内容");
            string newContent = Console.ReadLine();
            post.Content = newContent;
            bbl.pUpdate(post);
            DisplayPosts(blogID);


        }
        //删除帖子
        static void DeletePosts()
        {

            BlogBusinessLayera bbl = new BlogBusinessLayera();
            Console.WriteLine("请输入一个博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplayPosts(blogId);
            Console.WriteLine("请输入要删除的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            bbl.DeletePost(post);
            DisplayPosts(blogId);

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
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
