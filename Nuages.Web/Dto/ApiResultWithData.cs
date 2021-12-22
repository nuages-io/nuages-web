// ReSharper disable UnusedType.Global


namespace Nuages.Web.Dto;

public class ApiResultWithData<T> : ApiResult
{
    public ApiResultWithData(T? data)
    {
        Data = data;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public T? Data { get; }
}