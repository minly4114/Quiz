using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quiz.DataBase;
using Quiz.DataBase.IProviders;

namespace Quiz.Pages
{
    public class AddCounterModel : PageModel
    {
        private readonly ICountersProvider _countersProvider;
        public AddCounterModel(ICountersProvider countersProvider)
        {
            _countersProvider = countersProvider;
        }
        public string message;
        public void OnGet()
        {

        }
        public void OnPostView(string inputId, string inputValue)
        {
            message = "";
            int id = 0;
            int value = 0;
            if (int.TryParse(inputId, out int idResult) && int.TryParse(inputValue, out int valueResult))
            {
                id = idResult;
                value = valueResult;
                _countersProvider.AddCounterAsync(new List<Counter>()
                {
                new Counter(id, value),
                });
                message = "Counter успешно добавлен";
            }
            else
            {
                message = "Введите коректные данные ";
            }
        }
    }
}