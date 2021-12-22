namespace Nuages.Web.Exceptions;

public class NotAuthorizedException : Exception
{
    public NotAuthorizedException(string? message = null) : base(message)
    {
    }
}