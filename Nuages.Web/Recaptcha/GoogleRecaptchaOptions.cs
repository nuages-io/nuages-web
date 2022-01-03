using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Recaptcha;

[ExcludeFromCodeCoverage]
public class GoogleRecaptchaOptions
{
    public string SiteKey { get; set; } = String.Empty;
    public string SecretKey { get; set; } = String.Empty;
}