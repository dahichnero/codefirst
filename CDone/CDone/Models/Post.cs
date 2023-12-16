using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDone.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Publication { get; set; }
        public bool IsPublished { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}
