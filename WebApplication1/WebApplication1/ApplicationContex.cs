using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ApplicationContex: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContex(DbContextOptions<ApplicationContex> options)
        {
            Database.EnsureCreated();
        }

        //public ApplicationContex(DbContextOptions<ApplicationContex> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminLogin = "admin@mail.ru";
            var adminPassword = "turboadmin";

            var adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword};
            modelBuilder.Entity<User>().HasData(adminUser);

            base.OnModelCreating(modelBuilder);
        }
    }
}
