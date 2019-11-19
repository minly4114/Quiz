using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore;

namespace Quiz.DataBase
{
    public class PostgresContext:DbContext
    {
        public DbSet<Counter> Counters { get; set; }
        //public PostgresContext()
        //{
        //    Database.EnsureCreated();
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Database=Quiz;Username=postgres;Password=123;Port=5432");

        //}
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
