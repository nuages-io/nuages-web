using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Recaptcha;

[ExcludeFromCodeCoverage]
public class GoogleRecaptchaOptions
{
    public string SiteKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
}