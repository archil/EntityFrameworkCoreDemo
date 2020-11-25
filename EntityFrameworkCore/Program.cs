using EntityFrameworkCore.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingDbContext())
            {
                var blogsCount = db.Blogs.Count();

                Console.WriteLine($"There are {blogsCount} blogs in db");
            }
        }
    }

    public class BloggingDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=BloggingDb;Integrated security=true;");
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }

    public class Car
    {
        public string LicencePlateNumber { get; set; }
        public string Make { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public DateTime BlogDate { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int MyBlogForeignKeyValue { get; set; }
        public Blog Blog { get; set; }
    }
}
