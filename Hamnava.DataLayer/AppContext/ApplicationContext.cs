using Hamnava.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hamnava.DataLayer.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
