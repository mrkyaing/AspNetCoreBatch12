using Microsoft.AspNetCore.Mvc;
using StudentInfoMgt.DAO;
using StudentInfoMgt.Models;
namespace StudentInfoMgt.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _applicationDb;

        public StudentController(ApplicationDbContext db)
        {
            _applicationDb = db;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(StudentViewModel svm)
        {
            try
            {
                //Data transfer from viewmodel to dataModel(studentEntity) in here
                StudentEntity studentEntity = new StudentEntity()
                {
                    Id = Guid.NewGuid().ToString(),//this is system auto-generated string 36 value for used of  primay key
                    Name = svm.Name,
                    Email = svm.Email,
                    Phone = svm.Phone,
                    NRC = svm.NRC,
                    FatherName = svm.FatherName,
                    DOB = svm.DOB,
                    Address = svm.Address,
                    Code = svm.Code
                };
                _applicationDb.Students.Add(studentEntity);//adding the studetEntity to the DBSET in here 
                _applicationDb.SaveChanges();//saving the recrod to the connected database .
                TempData["info"] = "Successfully save the recrod to the system";
            }
            catch (Exception e)
            {
                TempData["info"] = "error occur when saving  the recrod to the system";
                throw;
            }
            return View();
        }
    }
}
