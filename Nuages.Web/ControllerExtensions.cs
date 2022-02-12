using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Nuages.Web;

// ReSharper disable once UnusedType.Global
public static class ControllerExtensions
{
    // ReSharper disable once UnusedMember.Global
    public static string? Sub(this Controller controller)
    {
        var res = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return !string.IsNullOrEmpty(res) ? res : controller.User.FindFirstValue("sub");
    }
}