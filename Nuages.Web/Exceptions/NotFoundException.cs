using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Exceptions;

[ExcludeFromCodeCoverage]
public class NotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }
}