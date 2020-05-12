using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YetAnotherNewsSite.Models;

namespace YetAnotherNewsSite.Data
{
    public class YetAnotherNewsSiteContext : DbContext
    {
        public YetAnotherNewsSiteContext(DbContextOptions<YetAnotherNewsSiteContext> options)
: base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //Test Data Delete after Fetching is made
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            new User
            {
                Userid = "1",
                UserName = "Test",
                Password = "123"
            };




        }
    }
}
