using CDone.Models;
using Microsoft.EntityFrameworkCore;

Seeder.InitialSeed();
var context = new BlogContext();
foreach (Post post in context.Posts)
{
    Console.WriteLine($"=={post.Name}==");
    Console.WriteLine(post.Text);
    Console.WriteLine(post.Publication);
}
foreach (Post post in context.Posts.Include(p => p.Blog))
{
    Console.WriteLine($"{post.Blog.NameBlog} - {post.Name}");
    Console.WriteLine(post.Text);
    Console.WriteLine(post.Publication);
}
/*var post = context.Posts.First();
context.Entry(post).Reference(p => p.Blog).Load();
Console.WriteLine($"{post.Blog.NameBlog} - {post.Name}");
Console.WriteLine(post.Text);
Console.WriteLine(post.Publication);*/


foreach (Post post in context.Posts.Include(p => p.Blog).OrderBy(p => p.Publication))
{
    Console.WriteLine($"{post.Blog.NameBlog} - {post.Name}");
    Console.WriteLine(post.Text);
    Console.WriteLine(post.Publication);
}
foreach (Post post1 in context.Posts.Include(p => p.Blog).Where(p => p.Blog.NameBlog == "Программирование"))
{
    Console.WriteLine($"{post1.Blog.NameBlog} - {post1.Name}");
    Console.WriteLine(post1.Text);
    Console.WriteLine(post1.Publication);
}
foreach (Post post1 in context.Posts.Include(p => p.Blog).Where(p => p.Publication.Year==DateTime.Now.Year))
{
    Console.WriteLine($"{post1.Blog.NameBlog} - {post1.Name}");
    Console.WriteLine(post1.Text);
    Console.WriteLine(post1.Publication);
}
foreach(Post post in context.Posts.Include(p => p.Blog))
{
    Console.WriteLine(post.Blog.NameBlog);
    Console.WriteLine(post.Blog.Posts.Count);
}



foreach (Blog blog in context.Blogs.Where(p=>p.Posts.Count>0))
{
    Console.WriteLine(blog.NameBlog);
    Console.WriteLine(blog.Author);
    Console.WriteLine(blog.Create);
}
foreach (Post post in context.Posts.Include(p => p.Blog).Where(p=>p.Publication.Year!=DateTime.Now.Year))
{
    Console.WriteLine(post.Blog.NameBlog);
    Console.WriteLine(post.Blog.Author);
    Console.WriteLine(post.Blog.Create);
}
foreach (Post post in context.Posts.Include(p => p.Blog))
{
    Console.WriteLine(post.Blog.NameBlog);
    Console.WriteLine(post.Blog.Author);
    Console.WriteLine(post.Blog.Create);
    foreach(Post post1 in post.Blog.Posts)
    {
        Console.WriteLine(post1.Name);
        Console.WriteLine(post1.Text);
        Console.WriteLine(post1.Publication);
    }
}