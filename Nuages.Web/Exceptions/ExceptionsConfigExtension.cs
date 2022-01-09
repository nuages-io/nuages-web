#region

using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Localization;
using Nuages.Web.Dto;

#endregion

namespace Nuages.Web.Exceptions;

// ReSharper disable once UnusedType.Global
public static class ExceptionsConfig
{
    private const string UnknownError = "UnknownError";

    private const string NotAuthorized = "NotAuthorized";
    // private const string NotFound = "NotFound";

    // ReSharper disable once UnusedMember.Global
    public static void UseNuagesException(this IApplicationBuilder app)
    {
        var settings = new JsonSerializerOptions
        {
            PropertyNamingPolicy= JsonNamingPolicy.CamelCase
        };

        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var localizer = (IStringLocalizer) context.RequestServices.GetService(typeof(IStringLocalizer))!;

                context.Response.ContentType = "text/json";

                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();

                string error;

                switch (exceptionHandlerPathFeature!.Error)
                {
                    case ValidationException ex:
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync(
                            JsonSerializer.Serialize(GetErrorMessage(ex, localizer), settings));
                        break;
                    }
                    case NotAuthorizedException:
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                        error = localizer.GetString(NotAuthorized)!;
                        await context.Response.WriteAsync(
                            JsonSerializer.Serialize(GetErrorMessage(error, localizer), settings));
                        break;
                    }
                    // case NotFoundException _:
                    // {
                    //     context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    //     
                    //     error = localizer.GetString(NotFound);
                    //   
                    //     
                    //     await context.Response.WriteAsync(
                    //         JsonConvert.SerializeObject(GetErrorMessage(error, localizer), settings));
                    //
                    //    
                    //     break;
                    // }
                    default:
                    {
                        context.Response.StatusCode = 500;
                        error = localizer.GetString(UnknownError)!;
                        await context.Response.WriteAsync(
                            JsonSerializer.Serialize(GetErrorMessage(error, localizer), settings));
                        break;
                    }
                }
            });
        });
    }

    private static ApiResult GetErrorMessage(ValidationException ex, IStringLocalizer localizer)
    {
        var errors = new List<MessageInfo>();

        ex.Errors.ForEach(e =>
        {
            var message = e.NeedLocalization
                ? string.Format(localizer.GetString(e.Message)!, e.Arguments)
                : string.Format(e.Message, e.Arguments);

            errors.Add(new MessageInfo
            {
                Code = e.NeedLocalization ? e.Message : null,
                Message = message,
                MessageType = MessageType.Error
            });
        });

        return new ApiResult {Errors = errors};
    }

    private static ApiResult GetErrorMessage(string error, IStringLocalizer localizer)
    {
        var errors = new List<MessageInfo>();

        var message = localizer.GetString(error);

        errors.Add(new MessageInfo
        {
            Code = error,
            Message = message!
        });

        return new ApiResult {Errors = errors};
    }
}