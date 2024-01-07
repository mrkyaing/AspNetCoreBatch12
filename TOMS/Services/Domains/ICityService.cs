using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface ICityService
    {
        //crud process for passenger domain
        void Create(CityEntity entity);//create process
        IList<CityEntity> ReteriveAll();//reterice process
        void Update(CityEntity entity);//update process 
        CityEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
