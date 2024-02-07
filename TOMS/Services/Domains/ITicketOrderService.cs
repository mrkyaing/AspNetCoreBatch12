using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;

namespace TOMS.Services.Domains
{
    public interface ITicketOrderService
    {
        //crud process for passenger domain
        void Create(TicketEntity ticket);//create process
        void Create(List<TicketEntity> tickets);//create process
        IList<TicketEntity> ReteriveAll();//reterice process

        //for available and non-available ticekts checking
        IList<SeatPlan> ReteriveByTicketOrderedDateAndRouteId(DateTime ticketOrderedDate,string routeId);//reterice process
        void Update(TicketEntity ticket);//update process 
        TicketEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
