using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample.Models
{
    class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //数据库外键
        public int BlogId { get; set; }

        //导航属性--能够通过贴纸直接访问博客
        public virtual Blog Blog { get; set; }
    }
}
