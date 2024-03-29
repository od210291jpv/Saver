﻿using Microsoft.EntityFrameworkCore;

namespace SaverBackend.Models
{
    public class ApplicationContext : DbContext
    {
        public static string ConnectionString = "Database=mobilesdb;Uid=user;Pwd=password;";
        //public static string ConnectionString = "Database=mobilesdb;Uid=root;Pwd=password;";

        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
