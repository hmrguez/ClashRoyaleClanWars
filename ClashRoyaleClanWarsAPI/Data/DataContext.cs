using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

    }
}
