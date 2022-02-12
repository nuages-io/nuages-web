using System.Security.Claims;

namespace Nuages.Web;

// ReSharper disable once UnusedType.Global
public static class ClaimPrincipalExtension
{
    // ReSharper disable once UnusedMember.Global
    public static string? Sub(this ClaimsPrincipal principal)
    {
        var res = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        
        return !string.IsNullOrEmpty(res) ? res : principal.FindFirstValue("sub");
    }
}