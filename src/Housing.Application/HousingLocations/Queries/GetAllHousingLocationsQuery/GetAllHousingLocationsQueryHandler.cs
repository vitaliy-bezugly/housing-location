using Housing.Application.Common.Interfaces;
using Housing.Application.Common.Models;
using Housing.Domain.Entities;
using MediatR;

namespace Housing.Application.HousingLocations.Queries.GetAllHousingLocationsQuery;

public class GetAllHousingLocationsQueryHandler : IRequestHandler<GetAllHousingLocationsQuery, PaginatedList<HousingLocationEntity>>
{
    private readonly IDatabaseContext _context;
    private readonly IQueryBuilder<HousingLocationEntity> _queryBuilder;

    public GetAllHousingLocationsQueryHandler(IDatabaseContext context, IQueryBuilder<HousingLocationEntity> queryBuilder)
    {
        _context = context;
        _queryBuilder = queryBuilder;
    }

    public Task<PaginatedList<HousingLocationEntity>> Handle(GetAllHousingLocationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<HousingLocationEntity> query = _context.HousingLocations.AsQueryable();
        IQueryable<HousingLocationEntity> sortedQuery = _queryBuilder.BuildSortingQuery(query, request.Attribute, request.Order == "asc" || request.Order == "ascending");
        
        return PaginatedList<HousingLocationEntity>.CreateAsync(sortedQuery, request.PageNumber, request.PageSize);
    }
}