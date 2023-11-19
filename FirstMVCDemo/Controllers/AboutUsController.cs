using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCDemo.Controllers
{
     //[Authorize]
    public class AboutUsController : Controller {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutUsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
       
        //host://port:about/index
        public IActionResult Index()
        {
            return View();
        }
        // //host://port/aboutus/CalculateSum?n1=Hello&n2=Hello
        public IActionResult CalculateSum(int n1,int n2)
        {
            int result = n1 + n2;
            ViewBag.Sum= result;
            return View();
        }
        [HttpGet]
        public IActionResult Search(string q)
        {
            string queryRresult = q;

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
        [HttpGet]
        public IActionResult Me(string firstName, string lastName)
        {
           string FullName = $"Hello,{firstName} {lastName}, Welcome to our system";
            ViewBag.Result = FullName;
            return View();
        }
        //host://port/aboutus/me
        [ActionName("me")]
        public IActionResult DoMe()
        {
            return View();
        }
        [NonAction]
        public ViewResult RandomNuber()
        {
            Random rnd = new Random();
            string result= rnd.Next(0, 100).ToString();
            ViewBag.Result=result;
            return View();
        }
    }
}
