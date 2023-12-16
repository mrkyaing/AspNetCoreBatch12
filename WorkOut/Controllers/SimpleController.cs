using Microsoft.AspNetCore.Mvc;
using WorkOut.Models;

namespace WorkOut.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string  ShowMeTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
        }

        public string ShowMeRandomNnumber()
        {
            return new Random().Next(0, 100).ToString();
        }
        public IActionResult MakeAnOrder()=>View();

        [HttpPost]
        public JsonResult MakeAnOrder(OrderModel order)
        {
            decimal TotalAmount = order.UnitPrice * order.Quantity;
            return Json(TotalAmount);
        }

    }
}
