#region

#endregion

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Nuages.Web.Dto;

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