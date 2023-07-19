using Housing.Application.Common.Exceptions;
using Housing.Application.Common.Interfaces;
using Housing.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Application.HousingLocations.Queries.GetHousingLocationQuery;

public class GetHousingLocationQueryHandler : IRequestHandler<GetHousingLocationQuery, HousingLocationEntity>
{
    private readonly IDatabaseContext _context;

    public GetHousingLocationQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<HousingLocationEntity> Handle(GetHousingLocationQuery request, CancellationToken cancellationToken)
    {
        HousingLocationEntity entity = await _context.HousingLocations
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
            ?? throw new NotFoundExceptions<HousingLocationEntity>(request.Id);

        return entity;
    }
}