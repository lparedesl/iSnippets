using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ISnippets.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Snippet> Snippets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Snippets.db");
        }
    }
}
