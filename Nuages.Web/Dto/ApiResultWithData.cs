// ReSharper disable UnusedType.Global


using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Dto;

[ExcludeFromCodeCoverage]
public class ApiResultWithData<T> : ApiResult
{
    public ApiResultWithData(T? data)
    {
        Data = data;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public T? Data { get; }
}