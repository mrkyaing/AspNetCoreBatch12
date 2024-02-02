using TOMS.DAO;
using TOMS.Models.DataModels;
using TOMS.Models.ViewModels;

namespace TOMS.Services.Domains
{
    public class TicketOrderService : ITicketOrderService
    {
        private readonly ApplicationDbContext _applicationDb;
        public TicketOrderService(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        public void Create(TicketEntity ticket)
        {
            _applicationDb.Tickets.Add(ticket);
            _applicationDb.SaveChanges();
        }

        public void Create(List<TicketEntity> tickets)
        {
            foreach (TicketEntity ticket in tickets)
            {
                _applicationDb.Tickets.Add(ticket);
                _applicationDb.SaveChanges();
            }
        }

        public void Delete(string Id)
        {
            var ticket = _applicationDb.Tickets.Find(Id);
            if (ticket != null)
            {
                _applicationDb.Tickets.Remove(ticket);
                _applicationDb.SaveChanges();
            }
        }

        public TicketEntity GetById(string id)
        {
            return _applicationDb.Tickets.Where(w => w.Id == id).SingleOrDefault();
        }

        public IList<TicketEntity> ReteriveAll()
        {
            return _applicationDb.Tickets.ToList();
        }

        public IList<SeatPlan> ReteriveByTicketOrderedDateAndRouteId(DateTime ticketOrderedDate, string routeId)
        {
            return _applicationDb.Tickets.Where(x=>x.TicketOrderedDate==ticketOrderedDate&&x.RouteId==routeId).Select(s=>new SeatPlan(s.SeatNo)).ToList();
        }

        public void Update(TicketEntity ticket)
        {
            _applicationDb.Tickets.Update(ticket);
            _applicationDb.SaveChanges();
        }
    }
}
