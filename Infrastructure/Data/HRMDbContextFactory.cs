using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class HRMDbContextFactory
    : IDesignTimeDbContextFactory<HRMDbContext>
{
    public HRMDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HRMDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=.;Database=HRM_DB;Trusted_Connection=True;TrustServerCertificate=True;"
        );

        return new HRMDbContext(optionsBuilder.Options);
    }
}
