using EmployeeMangment.Modules;
using Microsoft.EntityFrameworkCore;
namespace EmployeeMangment.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }


        
    }
}
