using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Nuages.Web.Exceptions;

public class ArgumentNullOrEmptyException : Exception
{
    private const string ArgumentIsNullOrEmpty = "Argment is null or empty";
        
    public ArgumentNullOrEmptyException()
        : base(ArgumentIsNullOrEmpty)
    {
    }

    public ArgumentNullOrEmptyException(string? paramName)
        : base(ArgumentIsNullOrEmpty + ":" + paramName)
    {
    }

    public ArgumentNullOrEmptyException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public static void ThrowIfNullOrEmpty([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument is null)
        {
            Throw(paramName);
        }
    }

    [DoesNotReturn]
    private static void Throw(string? paramName) =>
        throw new ArgumentNullOrEmptyException(paramName);
}