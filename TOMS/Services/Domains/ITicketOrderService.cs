using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface ITicketOrderService
    {
        //crud process for passenger domain
        void Create(TicketEntity ticket);//create process
        IList<TicketEntity> ReteriveAll();//reterice process
        void Update(TicketEntity ticket);//update process 
        TicketEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
