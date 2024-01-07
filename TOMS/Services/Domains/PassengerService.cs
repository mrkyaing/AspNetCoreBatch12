using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class PassengerService : IPassengerService
    {
        private readonly ApplicationDbContext _applicationDb;
        public PassengerService(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public void Create(PassengerEntity passenger)
        {
            _applicationDb.Passengers.Add(passenger);
            _applicationDb.SaveChanges();
        }

        public void Delete(string Id)
        {
           var pessenger=_applicationDb.Passengers.Find(Id);
           if(pessenger != null) { 
            _applicationDb.Passengers.Remove(pessenger);
            _applicationDb.SaveChanges();
            }
        }

        public PassengerEntity GetById(string id)
        {
            return _applicationDb.Passengers.Where(w=>w.Id==id).SingleOrDefault();
        }

        public IList<PassengerEntity> ReteriveAll()
        {
            return _applicationDb.Passengers.ToList();
        }

        public void Update(PassengerEntity passenger)
        {
           _applicationDb.Passengers.Update(passenger);
            _applicationDb.SaveChanges();
        }
    }
}
