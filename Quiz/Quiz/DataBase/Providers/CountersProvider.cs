using Quiz.DataBase.IProviders;
using Quiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.DataBase.Providers
{
    public class CountersProvider : ICountersProvider
    {
        private readonly PostgresContext _postgresContext;
        public CountersProvider(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }
        public void AddCounterAsync(List<Counter> counters)
        {
            _postgresContext.Counters.AddRange(counters);
            _postgresContext.SaveChangesAsync();
        }

        public IQueryable<Counter> GetCounters()
        {
            return _postgresContext.Counters.AsQueryable();
        }

        public List<CounterWithCount> GetCountersWithCount()
        {
            List<CounterWithCount> counterThisCounts = new List<CounterWithCount>();
            var counters = _postgresContext.Counters.AsQueryable();
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
