using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quiz.DataBase;

namespace Quiz.Pages
{
    public class AddCounterModel : PageModel
    {
        public string message;
        public void OnGet()
        {

        }
        public void OnPostView(string inputId, string inputValue)
        {
            message = "";
            int id = 0;
            int value = 0;
            try
            {
                id = Int32.Parse(inputId);
                value = Int32.Parse(inputValue);
                DatabaseAdapter.AddCounter(new List<Counter>()
                {
                new Counter(id, value),
                });
                message = "Counter успешно добавлен";
            }
            catch
            {
                message = "Введите коректные данные ";              
            }
        }
    }
}