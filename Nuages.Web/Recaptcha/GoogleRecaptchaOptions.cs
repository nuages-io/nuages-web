using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Recaptcha;

[ExcludeFromCodeCoverage]
public class GoogleRecaptchaOptions
{
    public string Key { get; set; } = String.Empty;
}