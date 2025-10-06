using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
