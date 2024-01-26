using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly ICityService _cityService;
        private readonly IBusLineService _busLineService;
        public RouteController(IRouteService routeService,ICityService cityService,IBusLineService busLineService)
        {
            _routeService = routeService;
            _cityService = cityService;
            _busLineService = busLineService;
        }
        public IActionResult List()
        {
            List<RouteViewModel> routes = _routeService.ReteriveAll().Select(s => new RouteViewModel
            {
                Id=s.Id,
                //FromCityId=s.FromCityId,
                FormCityName=_cityService.GetById(s.FromCityId).Name,
               // ToCityId=s.ToCityId,
                ToCityName=_cityService.GetById(s.ToCityId).Name,
                UnitPrice=s.UnitPrice,
                When=s.When,
                BusLineId=s.BusLineId,
                Owner=_busLineService.GetById(s.BusLineId).Owner,
                Remark=s.Remark
            }).ToList();
            return View(routes);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Entry()
        {
            ViewBag.FromCityIds=_cityService.ReteriveAll().Select(s=>new CityViewModel { Id=s.Id,Name=s.Name}).ToList();
            ViewBag.ToCityIds = _cityService.ReteriveAll().Select(s => new CityViewModel { Id = s.Id, Name = s.Name }).ToList();
            ViewBag.BusLineIds = _busLineService.ReteriveAll().Select(s => new BusLineViewModel { Id = s.Id, Owner = s.Owner }).ToList();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Entry(RouteViewModel routevm)
        {
            try
            {
                RouteEntity route = new RouteEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    FromCityId = routevm.FromCityId,
                    ToCityId = routevm.ToCityId,
                    UnitPrice = routevm.UnitPrice,
                    Remark = routevm.Remark,
                    BusLineId = routevm.BusLineId,
                    When=routevm.When
                };
                _routeService.Create(route);
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
                _routeService.Delete(id);
                TempData["info"] = "Delete successfully the recrod to the system.";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error when delete the recrod to the system.";
            }
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            var routeEntity= _routeService.GetById(id);
            RouteViewModel routeViewModel = new RouteViewModel()
            {
                Id = routeEntity.Id,
                FromCityId = routeEntity.FromCityId,
                FormCityName=_cityService.GetById(routeEntity.ToCityId).Name,
                ToCityId = routeEntity.ToCityId,
                ToCityName=_cityService.GetById(routeEntity.FromCityId).Name,
                When = routeEntity.When,
                BusLineId=routeEntity.BusLineId,
                Owner=_busLineService.GetById(routeEntity.BusLineId).Owner,
                Remark=routeEntity.Remark,
                UnitPrice=routeEntity.UnitPrice
            };
            ViewBag.FromCityIds = _cityService.ReteriveAll().Where(w=>w.Id!= routeEntity.FromCityId).Select(s => new CityViewModel { Id = s.Id, Name = s.Name }).ToList();
            ViewBag.ToCityIds = _cityService.ReteriveAll().Where(w => w.Id != routeEntity.ToCityId).Select(s => new CityViewModel { Id = s.Id, Name = s.Name }).ToList();
            ViewBag.BusLineIds = _busLineService.ReteriveAll().Where(w => w.Id != routeEntity.BusLineId).Select(s => new BusLineViewModel { Id = s.Id, Owner = s.Owner }).ToList();
            return View(routeViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(RouteViewModel routevm)
        {
            try
            {
                RouteEntity route = new RouteEntity()
                {
                    Id = routevm.Id,
                    FromCityId = routevm.FromCityId,
                    ToCityId = routevm.ToCityId,
                    UnitPrice = routevm.UnitPrice,
                    Remark = routevm.Remark,
                    BusLineId = routevm.BusLineId,
                    When = routevm.When,
                    UpdatedAt = DateTime.Now
                };
                _routeService.Update(route);
                TempData["info"] = "Update successfully the recrod to the system.";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error when Update the recrod to the system.";
            }
            return RedirectToAction("List");
        }
    }
}
