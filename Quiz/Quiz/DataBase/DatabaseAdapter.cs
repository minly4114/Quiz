using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DataBase
{
    public static class DatabaseAdapter
    {
        static DbContextOptions<PostgresContext> dbContextOptions;
        static PostgresContext pc;
        static DatabaseAdapter()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
            dbContextOptions = optionsBuilder.UseNpgsql(connectionString).Options;
            pc = new PostgresContext(dbContextOptions);
        }
        public static IQueryable<Counter> GetCounters()
        {
            return pc.Counters;
        }

        public static void AddCounter(List<Counter>  counters)
        {
            pc.Counters.AddRange(counters);
            pc.SaveChanges();
        }
        public static List<CounterWithCount> GetCountersWithCount()
        {
            List<CounterWithCount> counterThisCounts = new List<CounterWithCount>();
            var counters = pc.Counters.AsQueryable();
            var uniqueId = counters.ToList().ConvertAll(x => x.Id).Distinct().ToList();
            List<int> list = new List<int>();
            foreach (var id in uniqueId)
            {
                counterThisCounts.Add(new CounterWithCount()
                {
                    Id = id,
                    Count = counters.Where(x => x.Id.Equals(id)).Count(),
                    CountMoreTheNone = counters.Where(x => x.Id.Equals(id) && x.Value > 1).Count()
                });
            }
            return counterThisCounts;
        }
    }
}
