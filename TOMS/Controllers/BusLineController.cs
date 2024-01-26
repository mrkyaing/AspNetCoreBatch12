using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{ 
    public class BusLineController : Controller
    {
        private readonly IBusLineService _busLineService;

        public BusLineController(IBusLineService busLineService)
        {
            _busLineService = busLineService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Entry()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Entry(BusLineViewModel busLineView) {
            try
            {
                var busLineEntity = new BusLineEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    No = busLineView.No,
                    Owner = busLineView.Owner,
                    Driver1 = busLineView.Driver1,
                    Driver2 = busLineView.Driver2,
                    PhoneOfDriver2 = busLineView.PhoneOfDriver2,
                    PhoneOfDriver1 = busLineView.PhoneOfDriver1,
                    Helper1 = busLineView.Helper1,
                    Helper2 = busLineView.Helper2,
                    PhoneOfHelper1 = busLineView.PhoneOfHelper1,
                    PhoneOfHelper2 = busLineView.PhoneOfHelper2,
                    NumberOfSeat = busLineView.NumberOfSeat,
                    Type = busLineView.Type
                };
                _busLineService.Entry(busLineEntity);
                TempData["info"] = "Successfully Added Bus Line Record to the system";
            }
            catch (Exception)
            {
                TempData["info"] = "Failed to Add Busline Record to the system";
                
            }
           
            return View();
        }
        public IActionResult List()
        {
            IList<BusLineViewModel> BuslineView = _busLineService.ReteriveAll().Select(b=>new BusLineViewModel
            {
                Id=b.Id,
                No = b.No,
                Owner = b.Owner,
                Driver1 = b.Driver1,
                Driver2 = b.Driver2,
                PhoneOfDriver1 = b.PhoneOfDriver1,
                PhoneOfDriver2= b.PhoneOfDriver2,
                Helper1 = b.Helper1,
                Helper2 = b.Helper2,
                PhoneOfHelper1= b.PhoneOfHelper1,
                PhoneOfHelper2= b.PhoneOfHelper2,
                Type = b.Type,
                NumberOfSeat= b.NumberOfSeat,
            }).ToList();
            return View(BuslineView);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBusLine(string id)
        {
            try
            {
                _busLineService.Delete(id);
                TempData["info"] = "Successfully deleted Busline Data from the system";
                return RedirectToAction("list");
            }
            catch (Exception)
            {
                TempData["info"] = "Failed to delete Busline Data from the system";
                return RedirectToAction("list");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id) {
            BusLineViewModel busLineView = new BusLineViewModel();
            BusLineEntity busLineEntity= _busLineService.GetById(id);
            if(busLineEntity != null)
            {
                busLineView.Id = busLineEntity.Id;
                busLineView.No = busLineEntity.No;
                busLineView.Owner = busLineEntity.Owner;
                busLineView.Driver1 = busLineEntity.Driver1;
                busLineView.PhoneOfDriver1 = busLineEntity.PhoneOfDriver1;
                busLineView.PhoneOfDriver2 = busLineEntity.PhoneOfDriver2;
                busLineView.Driver2 = busLineEntity.Driver2;
                busLineView.Helper1 = busLineEntity.Helper1;
                busLineView.Helper2 = busLineEntity.Helper2;
                busLineView.PhoneOfHelper1 = busLineEntity.PhoneOfHelper1;
                busLineView.PhoneOfHelper2 = busLineEntity.PhoneOfHelper2;
                busLineView.Type= busLineEntity.Type;
                busLineView.NumberOfSeat = busLineEntity.NumberOfSeat;
            }
            return View(busLineView);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(BusLineViewModel busLineViewModel)
        {
            try
            {
                BusLineEntity busLineEntity = new BusLineEntity()
                {
                    Id = busLineViewModel.Id,
                    No = busLineViewModel.No,
                    Owner = busLineViewModel.Owner,
                    Driver1 = busLineViewModel.Driver1,
                    Driver2 = busLineViewModel.Driver2,
                    Helper1 = busLineViewModel.Helper1,
                    Helper2 = busLineViewModel.Helper2,
                    PhoneOfDriver1 = busLineViewModel.PhoneOfDriver1,
                    PhoneOfDriver2 = busLineViewModel.PhoneOfDriver2,
                    PhoneOfHelper1 = busLineViewModel.PhoneOfHelper1,
                    PhoneOfHelper2 = busLineViewModel.PhoneOfHelper2,
                    Type = busLineViewModel.Type,
                    NumberOfSeat = busLineViewModel.NumberOfSeat,
                    UpdatedAt = DateTime.Now,
                };
                _busLineService.Update(busLineEntity);
                TempData["info"] = "Successfully updated the busline data from the system";
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                TempData["info"] = "Failed to update the busline data from the system";
                return RedirectToAction("list");
            }
        }
    }
}
