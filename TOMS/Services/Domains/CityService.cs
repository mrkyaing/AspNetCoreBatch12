using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CityService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(CityEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public CityEntity GetById(string id)
        {
            return _applicationDbContext.Cities.Find(id);
        }

        public IList<CityEntity> ReteriveAll()
        {
            return _applicationDbContext.Cities.ToList();
        }

        public void Update(CityEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
