using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.DataBase;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class CounterWithCountController : Controller
    {
        public List<CounterWithCount> counterThisCounts;
        public CounterWithCountController()
        {
            counterThisCounts = DatabaseAdapter.GetCountersWithCount();
        }
        public IActionResult Index()
        {
            return View(DatabaseAdapter.GetCountersWithCount());
        }
    }
}