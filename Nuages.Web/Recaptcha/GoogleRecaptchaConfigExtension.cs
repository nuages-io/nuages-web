using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Recaptcha;

[ExcludeFromCodeCoverage]
// ReSharper disable once UnusedType.Global
public static class GoogleRecaptchaConfigExtension
{
    // ReSharper disable once UnusedMember.Global
    public static void AddGoogleRecaptcha(this IServiceCollection services, Action<GoogleRecaptchaOptions> configure )
    {
        AddGoogleRecaptcha(services, null, configure);
    }
    
    // ReSharper disable once MemberCanBePrivate.Global
    public static void AddGoogleRecaptcha(this IServiceCollection services, IConfiguration? configuration = null,  Action<GoogleRecaptchaOptions>? configure = null)
    {
        if (configuration != null)
        {
            services.Configure<GoogleRecaptchaOptions>(configuration.GetSection("Nuages:Web:GoogleRecaptcha"));
        }
        
        if (configure != null)
        {
            services.Configure(configure);
        }

        services.AddScoped<IRecaptchaValidator, GoogleRecaptchaValidator>();
    }
}