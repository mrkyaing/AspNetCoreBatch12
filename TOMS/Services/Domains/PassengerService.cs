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
            _applicationDb.Add(passenger);
            _applicationDb.SaveChanges();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<PassengerEntity> ReteriveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PassengerEntity passenger)
        {
            throw new NotImplementedException();
        }
    }
}
