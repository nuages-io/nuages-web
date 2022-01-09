using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Exceptions;

[ExcludeFromCodeCoverage]
// ReSharper disable once UnusedType.Global
public class NotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }
}