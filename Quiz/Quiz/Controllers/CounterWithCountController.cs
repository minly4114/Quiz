using Microsoft.AspNetCore.Mvc;
using Quiz.DataBase.IProviders;

namespace Quiz.Controllers
{
    public class CounterWithCountController : Controller
    {
        private readonly ICountersProvider _countersProvider;
        public CounterWithCountController(ICountersProvider countersProvider)
        {
            _countersProvider = countersProvider;
        }
        public IActionResult Index()
        {
            return View(_countersProvider.GetCountersWithCount());
        }
    }
}