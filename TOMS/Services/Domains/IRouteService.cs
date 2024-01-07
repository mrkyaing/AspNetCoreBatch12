using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface IRouteService
    {
        //crud process for passenger domain
        void Create(RouteEntity route);//create process
        IList<RouteEntity> ReteriveAll();//reterice process
        void Update(RouteEntity route);//update process 
        RouteEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
