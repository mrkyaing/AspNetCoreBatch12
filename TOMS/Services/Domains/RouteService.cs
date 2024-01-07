using TOMS.DAO;
using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public class RouteService : IRouteService
    {
        private readonly ApplicationDbContext _applicationDb;
        public RouteService(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        public void Create(RouteEntity route)
        {
            _applicationDb.Routes.Add(route);
            _applicationDb.SaveChanges();
        }

        public void Delete(string Id)
        {
            var route = _applicationDb.Routes.Find(Id);
            if (route != null)
            {
                _applicationDb.Routes.Remove(route);
                _applicationDb.SaveChanges();
            }
        }

        public RouteEntity GetById(string id)
        {
            return _applicationDb.Routes.Where(w => w.Id == id).SingleOrDefault();
        }

        public IList<RouteEntity> ReteriveAll()
        {
            return _applicationDb.Routes.ToList();
        }

        public void Update(RouteEntity route)
        {
            _applicationDb.Routes.Update(route);
            _applicationDb.SaveChanges();
        }
    }
}
