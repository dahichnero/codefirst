using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDone.Models
{
    public static class Seeder
    {
        public static void InitialSeed()
        {
            using (var context = new BlogContext())
            {
                if (!context.Blogs.Any())
                {
                    Blog blogFirst = new Blog
                    {
                        NameBlog = "Программирование",
                        Author = "programming@gmail.com",
                        Create = DateTime.Now.AddYears(-3)
                    };
                    Blog blogSecond = new Blog
                    {
                        NameBlog = "Библиотека",
                        Author = "library@gmail.com",
                        Create = DateTime.Now
                    };
                    Blog blogThree = new Blog
                    {
                        NameBlog = "Продажи",
                        Author = "forsale@gmail.com",
                        Create = DateTime.Now.AddDays(-60)
                    };
                    context.Blogs.Add(blogFirst);
                    context.Blogs.Add(blogSecond);
                    context.Blogs.Add(blogThree);
                    blogFirst.Posts.Add(new Post
                    {
                        Name = "Введение",
                        Text = "Сегодня поговорим о том, что такое программирование.",
                        Publication = DateTime.Now.AddYears(2)
                    });
                    blogFirst.Posts.Add(new Post
                    {
                        Name = "HTML",
                        Text = "Данный язык используется для составления сайтов.",
                        Publication = DateTime.Now.AddYears(2)
                    });
                    blogSecond.Posts.Add(new Post
                    {
                        Name = "Библиотекарь",
                        Text = "Это основной работник, который ведет учет книг и читателей.",
                        Publication = DateTime.Now
                    });
                    blogSecond.Posts.Add(new Post
                    {
                        Name = "Книги",
                        Text = "Основа всех библиотек, благодаря которым библиотека занимается своей деятельностью.",
                        Publication = DateTime.Now
                    });
                    blogSecond.Posts.Add(new Post
                    {
                        Name = "Списание книг",
                        Text = "Если на замену старой книги приходит новая, то её списывают и заменяют.",
                        Publication = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
