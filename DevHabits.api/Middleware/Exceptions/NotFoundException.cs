namespace DevHabits.api.Middleware.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string resourceName, string resourceId) : base($"'{resourceName}' with ID '{resourceId}' was not found.")
    { 
    }
}
