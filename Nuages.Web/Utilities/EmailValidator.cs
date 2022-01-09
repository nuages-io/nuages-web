using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nuages.Web.Utilities;

public interface IEmailValidator
{
    bool IsValidEmail(string email);
}

public class EmailValidator : IEmailValidator
{
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
            RegexOptions.None, TimeSpan.FromMilliseconds(200));

        // Examines the domain part of the email and normalizes it.
        static string DomainMapper(Match match)
        {
            try
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        return Regex.IsMatch(email,
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
    }
}

[ExcludeFromCodeCoverage]
// ReSharper disable once UnusedType.Global
public static class EmailValidatorConfig
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once UnusedMember.Global
    public static IServiceCollection AddEmailValidator(this IServiceCollection services)
    {
        services.AddTransient<IEmailValidator, EmailValidator>();

        return services;
    }
}