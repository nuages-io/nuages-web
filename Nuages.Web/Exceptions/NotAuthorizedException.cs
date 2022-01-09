using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Exceptions;

[ExcludeFromCodeCoverage]
// ReSharper disable once ClassNeverInstantiated.Global
public class NotAuthorizedException : Exception
{
    public NotAuthorizedException(string? message = null) : base(message)
    {
    }
}