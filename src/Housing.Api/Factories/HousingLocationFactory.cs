using AutoMapper;
using Housing.Api.Contracts.Models;
using Housing.Application.Common.Models;
using Housing.Domain.Entities;

namespace Housing.Api.Factories;

public class HousingLocationFactory : IMappingModelsFactory<HousingLocationEntity, HousingLocationModel>
{
    private readonly IMapper _mapper;

    public HousingLocationFactory(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PaginatedList<HousingLocationModel> ToPaginationListModel(PaginatedList<HousingLocationEntity> paginatedList)
    {
        var viewModels = paginatedList.Items.Select(_mapper.Map<HousingLocationModel>).ToList();
        var listViewMode = new PaginatedList<HousingLocationModel>(viewModels, paginatedList.TotalCount, 
            paginatedList.CurrentPage, paginatedList.Items.Count);
        
        return listViewMode;
    }

    public HousingLocationModel ToModel(HousingLocationEntity source)
    {
        return _mapper.Map<HousingLocationModel>(source);
    }
}