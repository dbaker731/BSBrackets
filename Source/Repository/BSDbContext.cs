using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class BSDbContext : DbContext
    {
        public BSDbContext() { }

        public DbSet<AppUser> Users { get; set; }

        public BSDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BSBracketDev;Trusted_Connection=True;");
        }
    }
}
