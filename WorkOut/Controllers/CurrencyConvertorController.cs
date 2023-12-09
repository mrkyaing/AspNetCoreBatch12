using Microsoft.AspNetCore.Mvc;

namespace WorkOut.Controllers
{
    public class CurrencyConvertorController : Controller
    {
        public IActionResult CurrencyConvertorV1()=>View();
        
        [HttpPost]
        public IActionResult CurrencyConvertorV1(string fromCurrency,decimal amount)
        {
            if (fromCurrency is null)
            {
                ViewBag.Msg = "There is no selected from currency";
                return View();
            }
            decimal result = 0;
            switch (fromCurrency)
            {
                case "usd":result = amount * 2000;break;
                case "sdg": result = amount * 2100; break;
                case "tbh":result = amount * 98;break;
            }
            ViewBag.Result=result;
            return View();
        }
        
        public IActionResult CurrencyConvertorV2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CurrencyConvertorV2(string fromCurrency, decimal amount)
        {
            if (fromCurrency is null)
            {
                ViewBag.Msg = "There is no selected from currency";
                return View();
            }
            decimal result = 0;
            switch (fromCurrency)
            {
                case "usd": result = amount * 2000.75M; break;
                case "sdg": result = amount * 2100.6M; break;
                case "tbh": result = amount * 98.78M; break;
            }
            ViewBag.SelectedFromCurrency=fromCurrency;//to show ui side
            ViewBag.InputedAmount=amount;//to show ui side 
            ViewBag.Result = result;
            return View();
        }
    }
}
