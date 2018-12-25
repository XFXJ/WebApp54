using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BlogBusinessLayer
{
    class BlogBusinessLayera
    {
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
        public List<Post> PostQuery(int Id)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Posts where b.BlogId == Id select b;
                return query.ToList();
            }
        }
        //新增帖子
        public void PostAdd(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
        //删除帖子
        public void DeletePost(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Post postQuery(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public void pUpdate(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //查询博客名称
        public List<Blog> QueryBlog(string name)
        {
            using (var db = new BloggingContext())
            {
                // 查询所有包含字符串name的博客
                var blogs = from b in db.Blogs
                            where b.Name.Contains(name)
                            select b;
                return blogs.ToList();
            }
        }
        //查询帖子
        public List<Post> QueryPosts(string Title)
        {
            using (var db = new BloggingContext())
            {
                // 查询所有包含字符串Title的帖子
                var post = from b in db.Posts
                            where b.Title.Contains(Title)
                            select b;
                return post.ToList();
            }
        }
        public List<Blog>Query()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs orderby b.Name select b;
                return query.ToList();
            }
        }

        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }

        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State =EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
