namespace Nuages.Web.S3;

public static class S3CloudStorageConfigExtensions
{
    public static IServiceCollection AddS3CloudStorage(this IServiceCollection services)
    {
        services.AddScoped<IS3CloudStorage, S3CloudStorage>();

        return services;
    }
}