#region

#endregion

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Dto;

[ExcludeFromCodeCoverage]
public class ApiResult
{
   
    public ApiResult()
    {
            
    }

    public ApiResult(bool success)
    {
        Success = success;
    }
        
    public bool Success { get; set; } = true;
        
    public List<MessageInfo>? Errors { get; set; }
        
}