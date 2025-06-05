
using EFGetStarted;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Objects;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CreateAndAddData();
            AdvancedQuery();
        }

        static void AdvancedQuery()
        {
            using (var context = new BloggingContext())
            {

                var result = from post in context.Posts
                             //.Include(post => post.PostType)
                             //.Include(post => post.User)
                             //.Include(post => post.Blog)
                             join status in context.Statuses on post.PostType.Status equals status.StatusId
                             select new
                             {
                                 post.PostType,
                                 post.Blog,
                                 post.User,
                             };

                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Blog.BlogId}, {item.Blog.IsPublic}, {item.Blog.Url}, {item.PostType.Name}, {item.User.Name}");
                }
            }
        }

        static public void CreateAndAddData()
        {
            using (var db = new BloggingContext())
            {
                if (db != null)
                {
                    // Create
                    Console.WriteLine("Inserting a new blog");
                    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                    db.SaveChanges();

                    // Read
                    Console.WriteLine("Querying for a blog");
                    var blog = db.Blogs
                        .OrderBy(b => b.BlogId)
                        .First();

                    // Update
                    Console.WriteLine("Updating the blog and adding a post");
                    blog.Url = "https://devblogs.microsoft.com/dotnet";
                    blog.Posts.Add(
                        new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                    db.SaveChanges();

                    // Delete
                    Console.WriteLine("Delete the blog");
                    db.Remove(blog);
                    db.SaveChanges();
                }
            }
        }

    }
}


//MainProgram program = new MainProgram();
//program.CreateAndAddData();

//public class MainProgram
//{
//    public void CreateAndAddData()
//    {
//        using (var db = new BloggingContext())
//        {
//            // Note: This sample requires the database to be created before running.
//            Console.WriteLine($"Database path: {db.DbPath}.");

//            // Create
//            Console.WriteLine("Inserting a new blog");
//            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
//            db.SaveChanges();

//            // Read
//            Console.WriteLine("Querying for a blog");
//            var blog = db.Blogs
//                .OrderBy(b => b.BlogId)
//                .First();

//            // Update
//            Console.WriteLine("Updating the blog and adding a post");
//            blog.Url = "https://devblogs.microsoft.com/dotnet";
//            blog.Posts.Add(
//                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
//            db.SaveChanges();

//            // Delete
//            Console.WriteLine("Delete the blog");
//            db.Remove(blog);
//            db.SaveChanges();
//        }
//    }
//}
