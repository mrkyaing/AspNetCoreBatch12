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
            return View();
        }
        public IActionResult Entry()
        {
            return View();
        }
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
    }
}
