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
        public void Create(BusLineEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public BusLineEntity GetById(string id)
        {
          return _applicationDbContext.BusLines.Find(id);
        }

        public IList<BusLineEntity> ReteriveAll()
        {
           return _applicationDbContext.BusLines.ToList();
        }

        public void Update(BusLineEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
