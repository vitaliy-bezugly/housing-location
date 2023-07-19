namespace Housing.Application.Common.Exceptions;

public class NotFoundExceptions<T> : Exception
{
    public NotFoundExceptions(int id) 
        : base($"{typeof(T).FullName} with {id} was not found.")
    {
        Id = id;
    }
    
    public NotFoundExceptions(int id, Exception innerException) 
        : base($"{typeof(T).FullName} with {id} was not found.", innerException)
    {
        Id = id;
    }
    
    public int Id { get; init; }
    public Type EntityType => typeof(T);
}