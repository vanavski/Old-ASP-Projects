using Microsoft.EntityFrameworkCore;
using BlogCore.Core.Entities;

namespace BlogCore.Db
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<User> Users { get; private set; }
        public DbSet<Post> Posts { get; private set; }
        public DbSet<Comment> Comments { get; private set; }

        public ApplicationContext()
        {
            _connectionString = new ApplicationConstructor().ConfigurationRoot["ConnectionString"];
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(i => i.Login);
            modelBuilder.Entity<Post>().HasIndex(i => i.Header);
        }
    }
}
