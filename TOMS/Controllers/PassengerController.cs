using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        public IActionResult List()
        {
            List<PassengerViewModel> passengers=_passengerService.ReteriveAll().Select(s=>new PassengerViewModel
            {
                Id =s.Id,
                Name = s.Name,
                NRC = s.NRC,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                Gender = s.Gender,
                DOB = s.DOB,
            }).ToList();
            return View(passengers);
        }
       
        [Authorize(Roles ="Admin")]
        public IActionResult Entry()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Entry(PassengerViewModel pvm)
        {
            try
            {
                //data exchange from view model to data model
                PassengerEntity passenger = new PassengerEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = pvm.Name,
                    NRC = pvm.NRC,
                    Email = pvm.Email,
                    Phone = pvm.Phone,
                    Address = pvm.Address,
                    Gender = pvm.Gender,
                    DOB = pvm.DOB,
                };
                _passengerService.Create(passenger);
                TempData["info"] = "Save successfully the recrod to the system.";              
            }
            catch (Exception e)
            {
                TempData["info"] = "Error when save the recrod to the system.";
            }
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _passengerService.Delete(id);
                TempData["info"] = "delete successfully the recrod from the system.";
            }
            catch(Exception e) 
            {
                TempData["info"] = "Error when delete the recrod from the system.";

            }
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {               
            var passengerDataModel = _passengerService.GetById(id);
            //data exchange from data model to view model
            PassengerViewModel passengerViewModel = new PassengerViewModel();
            var genderstatus = false;
           
            if (passengerDataModel != null)
            {
                passengerViewModel.Id= passengerDataModel.Id;
                passengerViewModel.Name= passengerDataModel.Name;
                passengerViewModel.Address = passengerDataModel.Address;
                passengerViewModel.DOB= passengerDataModel.DOB;
                passengerViewModel.Phone = passengerDataModel.Phone;
                passengerViewModel.Gender= passengerDataModel.Gender;
                passengerViewModel.Email= passengerDataModel.Email;
                passengerViewModel.NRC=passengerDataModel.NRC;
            }
            return View(passengerViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(PassengerViewModel pvm)
        {
            try
            {
                //data exchange from view model to data model
                PassengerEntity passenger = new PassengerEntity()
                {
                    Id = pvm.Id,
                    Name = pvm.Name,
                    NRC = pvm.NRC,
                    Email = pvm.Email,
                    Phone = pvm.Phone,
                    Address = pvm.Address,
                    Gender = pvm.Gender,
                    DOB = pvm.DOB,
                    UpdatedAt = DateTime.Now
                };
                _passengerService.Update(passenger);
                TempData["info"] = "Update successfully the recrod to the system.";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error when update the recrod to the system.";
            }
            return RedirectToAction("List");
        }
    }
}
