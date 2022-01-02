namespace Nuages.Web.Recaptcha;

public interface IRecaptchaValidator
{
    // ReSharper disable once UnusedMember.Global
    Task<bool> ValidateAsync(string? token);
}