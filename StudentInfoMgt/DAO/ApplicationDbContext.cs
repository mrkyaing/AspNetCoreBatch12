using Microsoft.EntityFrameworkCore;
using StudentInfoMgt.Models;

namespace StudentInfoMgt.DAO
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        //register for entity/table
        public DbSet<StudentEntity>  Students { get; set; }
    }
}
