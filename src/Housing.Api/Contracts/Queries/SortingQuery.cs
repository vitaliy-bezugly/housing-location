using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Contracts.Queries;

public class SortingQuery
{
    [FromQuery(Name = "attribute")]
    public string Attribute { get; set; } = string.Empty;
    [FromQuery(Name = "order")]
    public string Order { get; set; } = string.Empty;
}