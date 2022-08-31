using System;
using System.Collections.Generic;
using System.Text;
using FinderProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinderProject.DataAcces.DataContext
{
    public class FinderDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=FinderDB; Integrated Security=True");
        }

        public DbSet<Content> Contents { get; set; }
    }
}
