using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Nuages.Web;

public static class ControllerExtensions
{
    public static string? Sub(this Controller controller)
    {
        var res = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(res))
            return res;
        
        return controller.User.FindFirstValue("sub");
    }
}