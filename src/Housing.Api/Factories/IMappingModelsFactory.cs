using Housing.Application.Common.Models;

namespace Housing.Api.Factories;

public interface IMappingModelsFactory<TSource, TDesignation>
{ 
    PaginatedList<TDesignation> ToPaginationListModel(PaginatedList<TSource> paginatedList);
    
    TDesignation ToModel(TSource source);
}