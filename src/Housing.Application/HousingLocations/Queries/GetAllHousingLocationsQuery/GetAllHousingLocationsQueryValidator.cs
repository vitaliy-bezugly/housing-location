using FluentValidation;

namespace Housing.Application.HousingLocations.Queries.GetAllHousingLocationsQuery;

public class GetAllHousingLocationsQueryValidator : AbstractValidator<GetAllHousingLocationsQuery>
{
    public GetAllHousingLocationsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .LessThanOrEqualTo(50);
        
        RuleFor(x => x.Attribute)
            .Must(x => string.IsNullOrEmpty(x) || x == "id" || x == "name" || x == "city" || x == "state" || x == "availableUnits" || x == "wifi" || x == "laundry")
            .WithMessage("Attribute must be null or one of the following: id, name, city, state, availableUnits, wifi, laundry.");
        
        RuleFor(x => x.Order)
            .Must(x => string.IsNullOrEmpty(x) || x == "asc" || x == "desc" || x == "ascending" || x == "descending")
            .WithMessage("Order must be null or one of the following: asc, desc, ascending, descending.");
    }
}