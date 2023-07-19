using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Housing.Application.Common.Interfaces;

public interface IDatabaseContext
{
    public DbSet<HousingLocationEntity> HousingLocations { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}