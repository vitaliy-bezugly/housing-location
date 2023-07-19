using Housing.Application.Common.Interfaces;
using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IDatabaseContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<HousingLocationEntity> HousingLocations { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}