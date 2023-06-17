using Microsoft.EntityFrameworkCore;

namespace FactoryAndEFRaining.DataAccess;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
}