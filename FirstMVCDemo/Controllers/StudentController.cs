using FirstMVCDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        IList<StudentModel> students=new List<StudentModel>();
        [HttpPost]
        public IActionResult Register(string fristName,string lastName,string DOB,string address,string Gender) {
            students.Add(new StudentModel
            {
                FirstName = fristName,
                LastName = lastName,
                DOB =DateOnly.FromDateTime(Convert.ToDateTime(DOB)),
                Gender=Gender,
                Address = address
            });
            TempData["Info"] = "1 sutdent recrod is successfully registered";
            TempData["StudentCounts"] = students.Count;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
