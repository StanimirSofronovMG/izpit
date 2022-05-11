using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class StanimirSofronovDbContext : DbContext

    {
        public StanimirSofronovDbContext() { }
        public StanimirSofronovDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JARQ3N6;Database=StanimirSofronov_23_PT2;Trusted_Connection=True;");

        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}