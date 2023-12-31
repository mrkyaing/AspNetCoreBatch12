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
        public DbSet<TicketTypeEntity> TicketTypes { get; set; }
    }
}
