using System.Security.Claims;

namespace Nuages.Web;

public static class ClaimPrincipalExtension
{
    public static string? Sub(this ClaimsPrincipal principal)
    {
        var res = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (!string.IsNullOrEmpty(res))
            return res;
        
        return principal.FindFirstValue("sub");
    }
}