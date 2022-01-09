using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web;

// ReSharper disable once UnusedType.Global
public static class EndpointConfigExtension
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once UnusedMember.Global
    public static void MapCustomEndpoints(this IEndpointRouteBuilder endpoints, IServiceProvider serviceProviuder)
    {
        var endpointProviders = serviceProviuder.GetServices<IEndpointsProvider>();
        foreach (var provider in endpointProviders)
        {
            provider.ProvideEnpoints(endpoints);
        }
    }
}