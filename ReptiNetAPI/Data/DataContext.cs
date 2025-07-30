using Microsoft.EntityFrameworkCore;
using ReptiNetAPI.Models;

namespace ReptiNetAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Reptile> Reptiles { get; set; }
    }
}
