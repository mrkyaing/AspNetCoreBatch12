using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface ITicketOrderTransactionService
    {
        //crud process for passenger domain
        void Create(TicketOrderTransactionEntity ticket);//create process
        IList<TicketOrderTransactionEntity> ReteriveAll();//reterice process
        void Update(TicketOrderTransactionEntity ticket);//update process 
        TicketOrderTransactionEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
