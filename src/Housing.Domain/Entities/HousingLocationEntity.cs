namespace Housing.Domain.Entities;

public record HousingLocationEntity(int Id, string Name, string City, string State, 
    string Photo, int AvailableUnits, bool Wifi, bool Laundry);