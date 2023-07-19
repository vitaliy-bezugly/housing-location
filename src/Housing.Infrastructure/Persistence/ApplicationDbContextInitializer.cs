using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Housing.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlite())
            {
                await _context.Database.MigrateAsync();
            }
            else
            {
                string errorMessage = "Can not execute migration. Database provider not supported. Supported providers: Sqlite.";
                _logger.LogError(errorMessage);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error has occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        if (_context.HousingLocations.Any() == false)
        {
            _logger.LogInformation("Seeding database...");
            
            _context.HousingLocations.AddRange(new List<HousingLocationEntity>
            {
                new(1, "Cozy Apartments", "New York City", "New York", "cozy_apartments.jpg", 10, true, true),
                new(2, "Sunny Heights", "Los Angeles", "California", "sunny_heights.jpg", 5, true, false),
                new(3, "Green Valley Residences", "San Francisco", "California", "green_valley_residences.jpg", 8, true, true),
                new(4, "Harbor View Apartments", "Seattle", "Washington", "harbor_view_apartments.jpg", 12, true, true),
                new(5, "Riverside Homes", "Chicago", "Illinois", "riverside_homes.jpg", 6, false, true),
                new(6, "Mountain View Condos", "Denver", "Colorado", "mountain_view_condos.jpg", 3, true, false),
                new(7, "Oceanfront Villas", "Miami", "Florida", "oceanfront_villas.jpg", 15, true, true),
                new(8, "Urban Lofts", "Austin", "Texas", "urban_lofts.jpg", 9, true, true)
            });

            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeding database completed.");
        }
        else
        {
            _logger.LogInformation("Database already seeded.");
        }
    }
}