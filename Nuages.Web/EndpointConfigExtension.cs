namespace Nuages.Web;

public static class EndpointConfigExtension
{
    public static void MapCustomEndpoints(this IEndpointRouteBuilder endpoints, IServiceProvider serviceProviuder)
    {
        var endpointProviders = serviceProviuder.GetServices<IEndpointsProvider>();
        foreach (var provider in endpointProviders)
        {
            provider.ProvideEnpoints(endpoints);
        }
    }
}