
using Microsoft.EntityFrameworkCore;
using Domain;
namespace EFGetStarted
{

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                Database=EFCoreDemo;
                Trusted_Connection=True;
                MultipleActiveResultSets=true");
        }
    }


    //public class BloggingContext : DbContext
    //{
    //    public DbSet<Blog> Blogs { get; set; }
    //    public DbSet<Post> Posts { get; set; }

    //    public string DbPath { get; }

    //    public BloggingContext()
    //    {

    //        string path = AppContext.BaseDirectory;
    //        DbPath = System.IO.Path.Join(path, "blogging.db");
    //    }

    //    The following configures EF to create a Sqlite database file in the
    //    special "local" folder for your platform.
    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //        => options.UseSqlite($"Data Source={DbPath}");
    //}


}
