using Microsoft.EntityFrameworkCore;

namespace DemoAppMVC.Models
{
    public class DemoAppDBContext : DbContext
    {
        public DemoAppDBContext(DbContextOptions<DemoAppDBContext> opts) : base(opts)
        {
        }


            public DbSet<Staff> Staffs { get; set; }
    }
}

