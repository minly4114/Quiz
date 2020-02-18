using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quiz.DataBase;
using Quiz.DataBase.IProviders;

namespace Quiz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICountersProvider _countersProvider;
        public List<Counter> counters;
        public IndexModel(ICountersProvider countersProvider)
        {
            _countersProvider = countersProvider;
        }

        public IActionResult OnGet()
        {
            counters = _countersProvider.GetCounters().ToList();
            return Page();
        }
    }
}
