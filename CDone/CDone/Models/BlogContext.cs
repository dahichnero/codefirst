using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDone.Models
{
    internal class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=posting;Trusted_Connection=True;");
        }
    }
}
