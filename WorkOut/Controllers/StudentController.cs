using Microsoft.AspNetCore.Mvc;
using WorkOut.Models;
namespace WorkOut.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentModel studentModel)
        {
            ViewBag.StudentInfo = studentModel.FristName + studentModel.MiddleName + studentModel.LastName;
            return View();
        }

        public IActionResult RegisterAsList() => View();
        [HttpPost]
        public IActionResult RegisterAsList(List<StudentModel> studentModels)
        {
            ViewBag.TotalStudents=studentModels.Count;
            return View();
        }
    }
}
