using Microsoft.EntityFrameworkCore;
using webApi_Nupat_1.Model;

namespace webApi_Nupat_1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
                
        }

        public DbSet<Food> Foods { get; set; }
    }
}
