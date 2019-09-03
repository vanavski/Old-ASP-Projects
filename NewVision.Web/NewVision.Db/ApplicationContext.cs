using Microsoft.EntityFrameworkCore;
using NewVision.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Db
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(new ApplicationConfigurator().Root["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login);

            modelBuilder.Entity<Post>()
                .HasIndex(p => p.Title);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
