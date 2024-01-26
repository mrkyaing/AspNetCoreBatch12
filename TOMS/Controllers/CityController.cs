using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
           _cityService = cityService;
        }
        public IActionResult Entry()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Entry(CityViewModel cityViewModel) {
            try
            {
                CityEntity cityEntity = new CityEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = cityViewModel.Name,
                    Code = cityViewModel.Code,
                    ZipCode = cityViewModel.ZipCode,
                };
                _cityService.Create(cityEntity);
                TempData["info"] = "Successfully Added City data to the System";
                return View();
            }
            catch (Exception)
            {
                TempData["info"] = "Failed to Add City data to the System";
                return View();
            }
        }
        public IActionResult List()
        {
            
            IList<CityViewModel> cityViewModels=_cityService.ReteriveAll().Select(c=>new CityViewModel
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                ZipCode = c.ZipCode,
            }).ToList();
            return View(cityViewModels);
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _cityService.Delete(id);
                TempData["info"] = "Successfully deleted City data from the database";
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                TempData["info"] = "Failed to delete City data from the database";
                return RedirectToAction("list");
            }
        }
        public IActionResult Update(string id)
        {
            CityViewModel cityView=new CityViewModel();
            CityEntity cityEntity=_cityService.GetById(id);
            if (cityEntity != null)
            {
                cityView.Id=cityEntity.Id;
                cityView.Name=cityEntity.Name;
                cityView.Code=cityEntity.Code;
                cityView.ZipCode=cityEntity.ZipCode;

            }
            return View(cityView);
        }
        [HttpPost]
        public IActionResult Update(CityViewModel cityViewModel)
        {
            try
            {
                CityEntity cityEntity = new CityEntity()
                {
                    Id = cityViewModel.Id,
                    Name = cityViewModel.Name,
                    ZipCode = cityViewModel.ZipCode,
                    Code = cityViewModel.Code
                };
                _cityService.Update(cityEntity);
                TempData["info"] = "Successfully updated city Date from the database";
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                TempData["info"] = "Failed to update city Date from the database";
                return RedirectToAction("list");
            }
        }
    }
}
