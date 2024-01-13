using Microsoft.AspNetCore.Mvc;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;
using TOMS.Services.Domains;

namespace TOMS.Controllers
{
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _paymentservice;

        public PaymentTypeController(IPaymentTypeService paymentservice)
        {
            _paymentservice = paymentservice;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PaymentTypeViewModel paymentViewModel)
        {
           PaymentTypeEntity paymentTypeEntity=new PaymentTypeEntity() { 
                Id=Guid.NewGuid().ToString(),
                AccountName=paymentViewModel.AccountName,
                AccountNumber=paymentViewModel.AccountNumber,
                PaymentType=paymentViewModel.PaymentType,
           };
            _paymentservice.Entry(paymentTypeEntity);
                TempData["info"] = "Successfully Added the Payment Data to the system";

                return View();
            
            
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _paymentservice.Delete(id);
                TempData["info"] = "Successfully Deleted the payment data from the database";
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                TempData["info"] = "Failed to Delete the payment data from the database";
                return RedirectToAction("list");
            }
        }
        public IActionResult List()
        {
            IList<PaymentTypeViewModel> paymentViewModels=_paymentservice.RetrieveAll().Select(p=>new PaymentTypeViewModel
            {
                Id=p.Id,
                PaymentType = p.PaymentType,
                AccountName = p.AccountName,
                AccountNumber = p.AccountNumber,
            }).ToList();
            return View(paymentViewModels);
        }
        public IActionResult update(string id)
        {
            PaymentTypeViewModel payment = new PaymentTypeViewModel();
            var paymentData=_paymentservice.GetById(id);
            if (paymentData != null)
            {
                payment.Id = paymentData.Id;
                payment.PaymentType = paymentData.PaymentType;
                payment.AccountName = paymentData.AccountName;
                payment.AccountNumber = paymentData.AccountNumber;
            }
            return View(payment);
        }
        [HttpPost]
        public IActionResult update(PaymentTypeViewModel payment)
        {
            try
            {
                PaymentTypeEntity paymentTypeEntity = new PaymentTypeEntity()
                {
                    Id = payment.Id,
                    PaymentType = payment.PaymentType,
                    AccountName = payment.AccountName,
                    AccountNumber = payment.AccountNumber,
                };
                _paymentservice.Update(paymentTypeEntity);
                TempData["info"] = "Successfully updated the payment data from the system";
                return RedirectToAction("list");
            }
            catch (Exception)
            {

                TempData["info"] = "Failed to update the payment data from the system";
                return RedirectToAction("list");
            }
        }
    }
}
