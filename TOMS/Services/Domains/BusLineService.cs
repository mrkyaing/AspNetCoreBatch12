using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class BusLineService : IBusLineService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BusLineService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Delete(string id)
        {
            var busline=_applicationDbContext.BusLines.Find(id);
            if (busline!=null)
            {
                _applicationDbContext.BusLines.Remove(busline);
                _applicationDbContext.SaveChanges();
            }
        }

        public void Entry(BusLineEntity busLine)
        {
            _applicationDbContext.BusLines.Add(busLine);
            _applicationDbContext.SaveChanges();
        }

        public BusLineEntity GetById(string id)
        {
            return _applicationDbContext.BusLines.Find(id);
        }

        public IList<BusLineEntity> ReteriveAll()
        {
            IList<BusLineEntity> buslineList=_applicationDbContext.BusLines.ToList();
            return buslineList;
        }

        public void Update(BusLineEntity busLine)
        {
            _applicationDbContext.BusLines.Update(busLine);
            _applicationDbContext.SaveChanges();
        }
    }
}
