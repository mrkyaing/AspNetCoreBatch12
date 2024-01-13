using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using TOMS.Helper;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly IBusLineService _busLineService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IBusLineService busLineService,IWebHostEnvironment webHostEnvironment)
        {
            _busLineService = busLineService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult BusLineDetailReport()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BusLineDetailReport(string BusLineNo,string Type,string Owner)
        {
            IList<BusLineReportModel> busLineReports = _busLineService.ReteriveAll().Where(w => w.No == BusLineNo 
            || w.Type == Type 
            || w.Owner == Owner).
            Select(s => new BusLineReportModel
            {
                No = s.No,
                Type = s.Type,
                Owner = s.Owner,
                Driver1=s.Driver1,
                PhoneOfDriver1=s.PhoneOfDriver1,
                Helper1= s.Helper1
            }).ToList();
            if (busLineReports.Count>0)
            {
                var rdlcPath = Path.Combine(_webHostEnvironment.WebRootPath, "ReportFiles", "BusLineDetailReport.rdlc");
                var fs = new FileStream(rdlcPath, FileMode.Open);
                Stream reportDefination = fs;
                LocalReport localReport = new LocalReport();
                localReport.LoadReportDefinition(reportDefination);
                localReport.DataSources.Add(new ReportDataSource("BusLineDataSet", busLineReports));
                byte[] pdfFile = localReport.Render("pdf");
                fs.Close();
                return File(pdfFile, "application/pdf"); 
            }
            else
            {
                TempData["info"] = "There is no data to export pdf";
                return View();
            }
        }
    }
}
