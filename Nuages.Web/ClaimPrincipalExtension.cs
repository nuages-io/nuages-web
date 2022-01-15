using System.Security.Claims;

namespace Nuages.Web;

public static class ClaimPrincipalExtension
{
    public static string? Sub(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}