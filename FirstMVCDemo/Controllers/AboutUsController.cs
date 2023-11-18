using Microsoft.AspNetCore.Mvc;

namespace FirstMVCDemo.Controllers
{
    public class AboutUsController : Controller {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutUsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalculateSum(int n1,int n2)
        {
            int result = n1 + n2;
            ViewBag.Sum= result;
            return View();
        }

        public FileResult SimpleDownload()
        {
            string fileName = "wall.jpg";
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "downloadfiles//" + fileName);
            byte[] fileInBytes=System.IO.File.ReadAllBytes(filePath);
            return File(fileInBytes, "text/jpg", fileName);
        }
        [HttpGet]
        public IActionResult TellMeYourFullName()=>View();
        
        [HttpPost]
        public IActionResult TellMeYourFullName(string firstName,string lastName)
        {
            string fullName = $"Hello,{firstName} {lastName}, Welcome to our system";
            ViewBag.Result=fullName;
            return View();
        }
    }
}
