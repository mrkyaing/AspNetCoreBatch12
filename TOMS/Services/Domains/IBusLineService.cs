using TOMS.Models.DataModels;

namespace TOMS.Services.Domains
{
    public interface IBusLineService
    {
        void Entry(BusLineEntity busLine);
        IList<BusLineEntity> ReteriveAll();
        void Update(BusLineEntity busLine);
        BusLineEntity GetById(string id);
        void Delete(string id);
    }
}
