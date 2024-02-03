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
        public TicketOrderTransactionController(ITicketOrderTransactionService ticketOrderTransactionService,IPaymentTypeService paymentTypeService,IPassengerService passengerService)
        {
            this._ticketOrderTransactionService = ticketOrderTransactionService;
            this._paymentTypeService = paymentTypeService;
            _passengerService= passengerService;
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
    }
}
