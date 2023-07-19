using System.Text.Json.Serialization;
using Housing.Api.Mappings;
using Housing.Domain.Entities;

namespace Housing.Api.Contracts.Models;

public class HousingLocationModel : IMapFrom<HousingLocationEntity>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;
    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;
    [JsonPropertyName("photo")]
    public string Photo { get; set; } = string.Empty;
    [JsonPropertyName("availableUnits")]
    public int AvailableUnits { get; set; }
    [JsonPropertyName("wifi")]
    public bool Wifi { get; set; }
    [JsonPropertyName("laundry")]
    public bool Laundry { get; set; }
}