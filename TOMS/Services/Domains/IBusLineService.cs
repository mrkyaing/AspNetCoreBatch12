using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface IBusLineService
    {
        //crud process for passenger domain
        void Create(BusLineEntity entity);//create process
        IList<BusLineEntity> ReteriveAll();//reterice process
        void Update(BusLineEntity entity);//update process 
        BusLineEntity GetById(string id);//get the recrod to called the update function
        void Delete(string Id);//for delete process according to Id
    }
}
