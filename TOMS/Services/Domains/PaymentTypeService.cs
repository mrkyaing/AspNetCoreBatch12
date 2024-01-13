using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentTypeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Delete(string id)
        {
            var paymentData=_applicationDbContext.PaymentTypes.Find(id);
            if (paymentData != null)
            {
                _applicationDbContext.PaymentTypes.Remove(paymentData);
                _applicationDbContext.SaveChanges();
            }
        }

        public void Entry(PaymentTypeEntity payment)
        {
            _applicationDbContext.PaymentTypes.Add(payment);
            _applicationDbContext.SaveChanges();

        }

        public PaymentTypeEntity GetById(string id)
        {
            return _applicationDbContext.PaymentTypes.Find(id);
        }

        public IList<PaymentTypeEntity> RetrieveAll()
        {
            return _applicationDbContext.PaymentTypes.ToList();
        }

        public void Update(PaymentTypeEntity paymentEntity)
        {
            _applicationDbContext.PaymentTypes.Update(paymentEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}
