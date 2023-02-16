
namespace APITestBase.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Agent> Agents => Set<Agent>();
}