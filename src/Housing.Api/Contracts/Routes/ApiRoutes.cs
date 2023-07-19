namespace Housing.Api.Contracts.Routes;

public static class ApiRoutes
{
    private const string Version = "v1";
    private const string Base = "api" + "/" + Version;
    
    public static class HousingLocation
    {
        public const string GetById = Base + "/" + "housinglocation/{id:int}";
        public const string GetAll = Base + "/" + "housinglocation";
    }
}