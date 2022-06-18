using HR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Db


{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
