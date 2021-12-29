using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web;

public static class EndpointConfigExtension
{
    [ExcludeFromCodeCoverage]
    public static void MapCustomEndpoints(this IEndpointRouteBuilder endpoints, IServiceProvider serviceProviuder)
    {
        var endpointProviders = serviceProviuder.GetServices<IEndpointsProvider>();
        foreach (var provider in endpointProviders)
        {
            provider.ProvideEnpoints(endpoints);
        }
    }
}