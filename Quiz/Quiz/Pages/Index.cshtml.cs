using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Quiz.DataBase;

namespace Quiz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Counter> counters;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            counters = DatabaseAdapter.GetCounters().ToList();
            if (counters.Count <= 0)
            {
                DatabaseAdapter.AddCounter(new List<Counter>() {
                    new Counter(1, 1),
                    new Counter(1, 2),
                    new Counter(1, 3),
                    new Counter(2, 1),
                    new Counter(2, 1),
                    new Counter(2, 3),
                    new Counter(2, 1),
                });
                counters = DatabaseAdapter.GetCounters().ToList();
            }
        }

        public void OnGet()
        {

        }
    }
}
