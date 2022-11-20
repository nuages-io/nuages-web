namespace Nuages.Web;

// ReSharper disable once UnusedType.Global
public static class CorsConfigExtensions
{
    // ReSharper disable once MemberCanBePrivate.Global
    public const string AllowSpecificOrigins = "AllowSpecificOrigins";
    private const string AllowAnyOrigins = "AllowAnyOrigins";

    // ReSharper disable once UnusedMember.Global
    public static void AddCors(this IServiceCollection services, string[] domains)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(domains)
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });


            options.AddPolicy(AllowAnyOrigins,
                builder =>
                {
                    builder.AllowCredentials()
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
}