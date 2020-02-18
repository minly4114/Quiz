using Quiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.DataBase.IProviders
{
    public interface ICountersProvider
    {
        IQueryable<Counter> GetCounters();
        void AddCounterAsync(List<Counter> counters);
        List<CounterWithCount> GetCountersWithCount();
    }
}
