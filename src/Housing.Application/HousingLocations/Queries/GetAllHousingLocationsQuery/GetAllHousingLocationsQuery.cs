using Housing.Application.Common.Models;
using Housing.Domain.Entities;
using MediatR;

namespace Housing.Application.HousingLocations.Queries.GetAllHousingLocationsQuery;

public record GetAllHousingLocationsQuery : IRequest<PaginatedList<HousingLocationEntity>>
{
    private const int MaxPageSize = 50;

    public GetAllHousingLocationsQuery(int pageNumber, int pageSize, string attribute, string order)
    {
        PageNumber = pageNumber;
        Attribute = attribute;
        Order = order;
        PageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
    }
    
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public string Attribute { get; init; }
    public string Order { get; init; }
}