using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Recaptcha;

[ExcludeFromCodeCoverage]
internal class RecaptchaResult
{
    // ReSharper disable once InconsistentNaming
    public bool success { get; set; }
}