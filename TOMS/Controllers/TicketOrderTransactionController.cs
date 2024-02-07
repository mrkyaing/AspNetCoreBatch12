using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TicketOrderTransactionController : Controller
    {
        private readonly ITicketOrderTransactionService _ticketOrderTransactionService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IPassengerService _passengerService;
        private readonly ITicketOrderService _ticketOrderService;
        public TicketOrderTransactionController(ITicketOrderTransactionService ticketOrderTransactionService,IPaymentTypeService paymentTypeService,IPassengerService passengerService,ITicketOrderService ticketOrderService)
        {
            this._ticketOrderTransactionService = ticketOrderTransactionService;
            this._paymentTypeService = paymentTypeService;
            _passengerService= passengerService;
            _ticketOrderService = ticketOrderService;
        }

        public IActionResult List()
        {
            IList<OrderTransactionViewModel> orderTransactions = this._ticketOrderTransactionService.ReteriveAll().Select(b => new OrderTransactionViewModel
            {
                TnxNo = b.TnxNo,
                Status = b.Status,
                PaymentMethodId = this._paymentTypeService.GetById(b.PaymentTypeId).PaymentType,
                PassengerId = _passengerService.GetById(b.PassengerId).Name,
                NumberOfTickets = b.NumberOfTickets,
                TotalAmount = b.TotalAmount,
                Remark = b.Remark,
            }).ToList();
            return View(orderTransactions);
        }
        public IActionResult TicketOrderedDetail(string orderTransactionId)
        {
            List< TicketOrderedDetialViewModel> ticketOrders =_ticketOrderService.ReteriveAll().Where(w=>w.OrderTransactionId == orderTransactionId).Select(s=>new TicketOrderedDetialViewModel
            {
                RouteId = s.RouteId,
                TicketOrderedDate=s.TicketOrderedDate,
                PassengerType=s.PassengerType,
                SeatNo=s.SeatNo,
                SeatRow=s.SeatRow

            }).ToList();
            return View();
        }
    }
}
