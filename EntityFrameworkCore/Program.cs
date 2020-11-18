using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class BloggingDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=BloggingDb;Integrated security=true;");
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Car
    {
        public string LicencePlateNumber { get; set; }
    }

    public class Blog
    { 
        public int BlogId { get; set; }
        public string Url { get; set; }
        public decimal Rating { get; set; }
        public string Author { get; set; }
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
