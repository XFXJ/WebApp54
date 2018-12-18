using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample.Models
{
    class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        //导航属性--通过博客对象访问对应的一组贴纸
        public virtual List<Post> Posts { get; set; }
    }
}
