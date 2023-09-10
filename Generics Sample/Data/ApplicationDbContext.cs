using Generics_Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace Generics_Sample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
