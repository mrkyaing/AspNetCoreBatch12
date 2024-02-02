using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class TicketOrderTransactionService : ITicketOrderTransactionService
    {
        private readonly ApplicationDbContext _applicationDb;
        public TicketOrderTransactionService(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        public void Create(TicketOrderTransactionEntity orderTransactionEntity)
        {
            _applicationDb.TicketOrderTransactions.Add(orderTransactionEntity);
            _applicationDb.SaveChanges();
        }

        public void Delete(string Id)
        {
            var orderTransactionEntity = _applicationDb.TicketOrderTransactions.Find(Id);
            if (orderTransactionEntity != null)
            {
                _applicationDb.TicketOrderTransactions.Remove(orderTransactionEntity);
                _applicationDb.SaveChanges();
            }
        }

        public TicketOrderTransactionEntity GetById(string id)
        {
            return _applicationDb.TicketOrderTransactions.Where(w => w.Id == id).SingleOrDefault();
        }

        public IList<TicketOrderTransactionEntity> ReteriveAll()
        {
            return _applicationDb.TicketOrderTransactions.ToList();
        }

        public void Update(TicketOrderTransactionEntity orderTransactionEntity)
        {
            _applicationDb.TicketOrderTransactions.Update(orderTransactionEntity);
            _applicationDb.SaveChanges();
        }
    }
}
