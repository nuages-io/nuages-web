#region

#endregion

namespace Nuages.Web.Exceptions;

// ReSharper disable once UnusedType.Global
public class ValidationException : Exception
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once CollectionNeverQueried.Global
    public readonly List<ValidationError> Errors = new();

    public ValidationException(string errorMessage, bool needLocalization = true, params object[] args) : base(
        errorMessage)
    {
        Errors.Add(new ValidationError
        {
            Message = errorMessage,
            NeedLocalization = needLocalization,
            Arguments = args
        });
    }
}

public class ValidationError
{
    public ValidationError()
    {
        NeedLocalization = true;
    }

    public string Message { get; set; } = string.Empty;
    public bool NeedLocalization { get; set; } 
    public object[] Arguments { get; set; } = Array.Empty<object>();
}