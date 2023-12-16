using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDone.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string NameBlog { get; set; }
        public string Author { get; set; }
        public DateTime Create { get; set; }
        public List<Post> Posts { get; set; }
    }
}
