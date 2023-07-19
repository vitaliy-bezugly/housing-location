using Housing.Domain.Entities;
using MediatR;

namespace Housing.Application.HousingLocations.Queries.GetHousingLocationQuery;

public record GetHousingLocationQuery(int Id) : IRequest<HousingLocationEntity>;