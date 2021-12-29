using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Exceptions;

[ExcludeFromCodeCoverage]
public class NotAuthorizedException : Exception
{
    public NotAuthorizedException(string? message = null) : base(message)
    {
    }
}