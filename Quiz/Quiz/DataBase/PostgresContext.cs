using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quiz.DataBase
{
    public class PostgresContext : DbContext
    {
        public DbSet<Counter> Counters { get; set; }
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Counter> counters = new List<Counter>() {
                    new Counter(1, 1),
                    new Counter(1, 2),
                    new Counter(1, 3),
                    new Counter(2, 1),
                    new Counter(2, 1),
                    new Counter(2, 3),
                    new Counter(2, 1)
            };
            modelBuilder.Entity<Counter>().HasData(counters);
        }
    }
}
