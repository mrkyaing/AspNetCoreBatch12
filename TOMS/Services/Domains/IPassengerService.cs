using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface IPassengerService
    {
        //crud process for passenger domain
        void Create(PassengerEntity passenger);//create process
        IList<PassengerEntity> ReteriveAll();//reterice process
        void Update(PassengerEntity passenger);//update process 
        void Delete(string Id);//for delete process according to Id
    }
}
