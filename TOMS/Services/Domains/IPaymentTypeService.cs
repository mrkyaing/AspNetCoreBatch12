using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface IPaymentTypeService
    {

        void Entry(PaymentTypeEntity payment);
        IList<PaymentTypeEntity> RetrieveAll();
        void Update(PaymentTypeEntity paymentEntity);
        PaymentTypeEntity GetById(string id);
        void Delete(string id);
    }
}
