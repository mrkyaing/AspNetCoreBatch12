using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TOMS.Models.DataModels;

namespace TOMS.DAO
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //register all of the entities for tables
        public DbSet<PassengerEntity>  Passengers { get; set; }
        public DbSet<BusLineEntity> BusLines { get; set; }
        public DbSet<CityEntity>  Cities { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<PaymentTypeEntity> PaymentTypes { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketOrderTransactionEntity> TicketOrderTransactions { get; set; }
    }
}
