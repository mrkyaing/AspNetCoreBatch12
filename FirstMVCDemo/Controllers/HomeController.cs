using Microsoft.AspNetCore.Mvc;
namespace FirstMVCDemo.Controllers
{
    public class HomeController :Controller
    {
        //applicationUrl://home/sayhello
        public string SayHello()
        {
            return "Hello,nice  to see you!!";
        }
        //applicationUrl://home/greetingmessage
        public string GreetingMessage()
        {
            return "I am fine to meet with you";
        }

        //applicationUrl://home/tellname?name=Mg Mg 
        public string TellName(string name)
        {
            return "Hello,"+name+" are you happy today?";
        }
        //  //applicationUrl://home/index
        public ViewResult Index()
        {
            string message =string.Empty;
            int hours = DateTime.Now.Hour;
            message = hours < 12 ? "Good Morning" : "Good Afternoon";
            ViewBag.Info=message;
            int i = 10;
            return View();
        }
    }
}
