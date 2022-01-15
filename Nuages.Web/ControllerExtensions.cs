using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Nuages.Web;

public static class ControllerExtensions
{
    public static string? Sub(this Controller controller)
    {
        return controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}