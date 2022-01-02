using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Nuages.Web.Exceptions;
// ReSharper disable MemberCanBePrivate.Global

namespace Nuages.Web.Recaptcha;

public class GoogleRecaptchaValidator : IRecaptchaValidator
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly GoogleRecaptchaOptions _options;

    public GoogleRecaptchaValidator(IHttpClientFactory clientFactory, IOptions<GoogleRecaptchaOptions> options)
    {
        _clientFactory = clientFactory;
        _options = options.Value;
    }

    public async Task<bool> ValidateAsync(string? token)
    {
     
        if (string.IsNullOrEmpty(_options.Key))
            return string.IsNullOrEmpty(token);
           
        var httpClient = _clientFactory.CreateClient();

        var res = await httpClient.GetAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={_options.Key}&response={token}");

        if (res.StatusCode != HttpStatusCode.OK)
        {
            //TODO : LogEvent
            return false;
        }

        var jsonRes = await res.Content.ReadAsStringAsync();
        var jsonData = JsonSerializer.Deserialize<RecaptchaResult>(jsonRes);

        return jsonData!.success ;
    }
}