using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;
using TOMS.Services.Utilities;

namespace TOMS.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IPassengerService _passengerService;
        private readonly ITicketOrderService _ticketOrderService;
        private readonly ITicketOrderTransactionService _ticketOrderTransactionService;

        public PaymentController(IPaymentTypeService paymentTypeService,IPassengerService passengerService,ITicketOrderService ticketOrderService,ITicketOrderTransactionService ticketOrderTransactionService)
        {
            _paymentTypeService = paymentTypeService;
            _passengerService = passengerService;
            _ticketOrderService = ticketOrderService;
            this._ticketOrderTransactionService = ticketOrderTransactionService;
        }
        [HttpPost]
        public IActionResult PaymentConfirm(PaymentConfirmViewModel paymentConfirmViewModel)
        {
            TicketViewModel ticket= SessionHelper.GetDataFromSession<TicketViewModel>(HttpContext.Session, "ticketInfos");
            var paymentType = _paymentTypeService.GetById(paymentConfirmViewModel.PaymentTypeId);
            var  paymentTypeInfo = new PaymentTypeViewModel()
            {
                AccountName=paymentType.AccountName,
                AccountNumber=paymentType.AccountNumber,
                PaymentType=paymentType.PaymentType
            };
            paymentConfirmViewModel.PaymentTypeInfo = paymentTypeInfo;
            paymentConfirmViewModel.Ticket = ticket;
            return View("MakePayment",paymentConfirmViewModel);
        }
        public IActionResult MakePayment()=> View();

        [HttpPost]
        public IActionResult MakePayment(PaymentConfirmViewModel paymentConfirmViewModel)
        {
            TicketViewModel tickets = SessionHelper.GetDataFromSession<TicketViewModel>(HttpContext.Session, "ticketInfos");
           //collect the passenger info
            var passenger = new PassengerEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = paymentConfirmViewModel.Name,
                NRC = paymentConfirmViewModel.NRC,
                Email = paymentConfirmViewModel.Email,
                Phone = paymentConfirmViewModel.Phone,
                Address = paymentConfirmViewModel.Address,
                Gender = paymentConfirmViewModel.Gender
            };
            //collect the Ticket Order Transaction info
            var ticketOrderTransaction = new TicketOrderTransactionEntity()
            {
                Id = Guid.NewGuid().ToString(),
                TnxNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Status = "Unpaid",
                PaymentTypeId = paymentConfirmViewModel.PaymentTypeId,
                PassengerId = passenger.Id,
                NumberOfTickets = tickets.NumberOfTickets,
                TotalAmount = tickets.TotalAmount,
                Remark = "Nothings",
                ScreenShootUrl = "/Images/PaymentReceived/a.png"
            };
            //collect the Tickets info
            var ticketOrders = new List<TicketEntity>();
            for(int i=0;i<tickets.NumberOfTickets;i++)
            {
                var  t = new TicketEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    RouteId =tickets.RouteId,
                    TicketOrderedDate=tickets.TicketOrderedDate,
                    PassengerType=tickets.PassengerType,
                    SeatNo = tickets.SeatsNo[i],
                    SeatRow = tickets.SeatRows[i],
                   SeatPlace = tickets.SeatsNo[i].Contains("1")?"WindowSide":"LaneSide",
                    Status ="Reserved",
                    OrderTransactionId= ticketOrderTransaction.Id
                };
                ticketOrders.Add(t);
            }
            //saving the Passenger info to the database 
            _passengerService.Create(passenger);
            //saving the ticketOrderTransaction info to the database 
            _ticketOrderTransactionService.Create(ticketOrderTransaction);
            //saving the ticketOrders info to the data base 
            _ticketOrderService.Create(ticketOrders);
           
            //passing the txno,Number of Seats ,Seat(s) No to the ui
            paymentConfirmViewModel.TxNo = ticketOrderTransaction.TnxNo;
            paymentConfirmViewModel.Ticket = tickets;
            //clear the ticket infos session
            SessionHelper.ClearSession(HttpContext.Session);       
            return View("TicketVouchorHistoryList",paymentConfirmViewModel);
        }
       public IActionResult TicketVouchorHistoryList()
        {
            return View();
        }
    }
}
