﻿using Microsoft.EntityFrameworkCore;
using OneToManyRelations.Models;

namespace OneToManyRelations.Data
{
    public class RelationsDbContext : DbContext
    {
        public RelationsDbContext()
        {
        }

        public RelationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
