namespace Nuages.Web;


public interface IEndpointsProvider
{
    void ProvideEnpoints(IEndpointRouteBuilder endpoints);
}