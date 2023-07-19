using AutoMapper;
using Housing.Api.Contracts.Models;
using Housing.Api.Contracts.Queries;
using Housing.Api.Contracts.Routes;
using Housing.Api.Factories;
using Housing.Application.HousingLocations.Queries.GetAllHousingLocationsQuery;
using Housing.Application.HousingLocations.Queries.GetHousingLocationQuery;
using Housing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Controllers;

[ApiController]
public class HousingLocationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMappingModelsFactory<HousingLocationEntity, HousingLocationModel> _mappingFactory;

    public HousingLocationController(IMediator mediator, IMapper mapper, IMappingModelsFactory<HousingLocationEntity, HousingLocationModel> mappingFactory)
    {
        _mediator = mediator;
        _mappingFactory = mappingFactory;
    }
    
    [HttpGet, Route(ApiRoutes.HousingLocation.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, [FromQuery] SortingQuery sortingQuery)
    {
        var query = new GetAllHousingLocationsQuery(paginationQuery.PageNumber, paginationQuery.PageSize, sortingQuery.Attribute, sortingQuery.Order);
        var result = await _mediator.Send(query);
        
        return Ok(_mappingFactory.ToPaginationListModel(result));
    }
    
    [HttpGet, Route(ApiRoutes.HousingLocation.GetById)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var query = new GetHousingLocationQuery(id);
        var result = await _mediator.Send(query);
        
        return Ok(_mappingFactory.ToModel(result));
    }
}