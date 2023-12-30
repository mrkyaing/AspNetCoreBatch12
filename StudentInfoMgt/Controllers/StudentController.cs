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

        #region create process 
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
        #endregion

        public IActionResult List()
        {
            //Data exchange from Data Model to view Models
           List<StudentViewModel> students=_applicationDb.Students.Select(s=>new StudentViewModel()
           {
               Id=s.Id,
               Name = s.Name,
               Code=s.Code,
               Phone = s.Phone,
               Email=s.Email,
               NRC = s.NRC,
               FatherName = s.FatherName,
               DOB = s.DOB,
               Address = s.Address
           }).ToList();
            return View(students);//passing the data to the View 
        }

        public IActionResult Delete(string id)
        {
            StudentEntity student=_applicationDb.Students.Where(w=>w.Id==id).SingleOrDefault();
            if (student != null)
            {
            _applicationDb.Remove(student);//
              _applicationDb.SaveChanges();
              TempData["info"] = "successfully deleted the record from the system";
            }          
         return RedirectToAction("list");
        }
    
        public IActionResult Edit(string id)
        {
           StudentViewModel svm= _applicationDb.Students.Where(w => w.Id == id).Select(s=>new StudentViewModel
           {
               Id = s.Id,
               Name = s.Name,
               Code = s.Code,
               Phone = s.Phone,
               Email = s.Email,
               NRC = s.NRC,
               FatherName = s.FatherName,
               DOB = s.DOB,
               Address = s.Address
           }).SingleOrDefault();
            return View(svm);
        }
        [HttpPost]
        public IActionResult Update(StudentViewModel svm)
        {
            try
            {
                //Data transfer from viewmodel to dataModel(studentEntity) in here
                StudentEntity studentEntity = new StudentEntity()
                {
                    Id =svm.Id,//this id is primary key in db if so, it will be update this key
                    Name = svm.Name,
                    Email = svm.Email,
                    Phone = svm.Phone,
                    NRC = svm.NRC,
                    FatherName = svm.FatherName,
                    DOB = svm.DOB,
                    Address = svm.Address,
                    Code = svm.Code
                };
                _applicationDb.Students.Update(studentEntity);//update the studetEntity to the DBSET in here 
                _applicationDb.SaveChanges();//updating the recrod to the connected database .
                TempData["info"] = "Update Successfully the recrod to the system";
            }
            catch (Exception e)
            {
                TempData["info"] = "error occur when updating  the recrod to the system";
                throw;
            }
            return RedirectToAction("List");
        }
    }
}
