using Microsoft.EntityFrameworkCore;
using TOMS.Models.DataModels;

namespace TOMS.DAO
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //register all of the entities for tables
        public DbSet<PassengerEntity>  Passengers { get; set; }
        public DbSet<BusLineEntity> BusLines { get; set; }
        public DbSet<CityEntity>  Cities { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
    }
}
