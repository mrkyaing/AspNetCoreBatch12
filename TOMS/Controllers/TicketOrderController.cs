using Microsoft.AspNetCore.Mvc;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;
using TOMS.Services.Utilities;

namespace TOMS.Controllers
{
    public class TicketOrderController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IRouteService _routeService;
        private readonly IBusLineService _busLineService;

        public TicketOrderController(ICityService cityService,IRouteService routeService , IBusLineService busLineService)
        {
            _cityService = cityService;
            _routeService = routeService;
            _busLineService = busLineService;
        }
        public IActionResult SearchRoute()
        {
            ViewBag.BusLineTypes = new List<string>() { ConstantsModel.BUS_LINE_TYPE_VIP, ConstantsModel.BUS_LINE_TYPE_NORMAL };
            ViewBag.PassengeTypes = new List<string>() { ConstantsModel.PASSENGER_TYPE_LOCAL, ConstantsModel.PASSENGER_TYPE_FOREIGN };
            List<SearchRouteViewModel> routeViewModels = _cityService.ReteriveAll().Select(s => new SearchRouteViewModel()
            {
                FromCityId = s.Id,
                FromCityName = _cityService.GetById(s.Id).Name,
                ToCityId = s.Id,
                ToCityName = _cityService.GetById(s.Id).Name
            }).ToList() ;
            return View(routeViewModels);
        }
        [HttpGet]
        public IActionResult SearchRouteBy(SearchRouteViewModel searchRouteViewModel)
        {
            var Buslines = _busLineService.ReteriveAll().Where(w => w.Type == searchRouteViewModel.BusLineType).Select(b => new BusLineViewModel
            {
                Id = b.Id,
                No = b.No,
                Owner = b.Owner,
                Driver1 = b.Driver1,
                Driver2 = b.Driver2,
                PhoneOfDriver1 = b.PhoneOfDriver1,
                PhoneOfDriver2 = b.PhoneOfDriver2,
                Helper1 = b.Helper1,
                Helper2 = b.Helper2,
                PhoneOfHelper1 = b.PhoneOfHelper1,
                PhoneOfHelper2 = b.PhoneOfHelper2,
                Type = b.Type,
                NumberOfSeat = b.NumberOfSeat,
            }).ToList();
          
           var routes = _routeService.ReteriveAll() .Where(w => w.FromCityId == searchRouteViewModel.FromCityId || w.ToCityId == searchRouteViewModel.ToCityId)
             .Select(s => new RouteViewModel()
             {
                 Id = s.Id,
                 FromCityId = s.FromCityId,
                 FormCityName = _cityService.GetById(s.FromCityId).Name,
                 ToCityId = s.ToCityId,
                 ToCityName = _cityService.GetById(s.ToCityId).Name,
                 UnitPrice = s.UnitPrice,
                 When = s.When,
                 BusLineId = s.BusLineId,
                 //getting the Owner Name by checking with busLine Id 
                 Owner = _busLineService.GetById(s.BusLineId).Owner,
                 Remark = s.Remark
             }).ToList();


            List<SearchRouteResultViewModel> searchRouteResults = (from b in Buslines 
                                                                                        join r in routes 
                                                                                        on b.Id equals r.BusLineId
                                                                                        select new SearchRouteResultViewModel
                                                                                        {
                                                                                            RouteId=r.Id,
                                                                                            Type=b.Type,
                                                                                            Owner=b.Owner,
                                                                                            NumberOfSeat=b.NumberOfSeat,
                                                                                            FormCityName=r.FormCityName,
                                                                                            ToCityName=r.ToCityName,
                                                                                            UnitPrice=r.UnitPrice,
                                                                                            When = r.When,
                                                                                            Remark=r.Remark
                                                                                        }).ToList();
            return View("SearchRouteResult", searchRouteResults);
        }

        public IActionResult SearchRouteResult() => View();

        [HttpGet]
        public IActionResult SelectRouteByPassenger(string routeId)
        {
            var busLineId = _routeService.GetById(routeId).BusLineId;
            SeatPlanViewModel seatPan = new SeatPlanViewModel()
            {
                NumberOfSeat = _busLineService.GetById(busLineId).NumberOfSeat,
                RouteId = routeId
            };
            return View(seatPan);
        }
        [HttpPost]
        public JsonResult SelectSeatNo(TicketViewModel ticket)
        {
            return Json(ticket);
        }
    }
}
