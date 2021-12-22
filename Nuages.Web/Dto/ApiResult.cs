#region

#endregion

namespace Nuages.Web.Dto;

public class ApiResult
{
    // ReSharper disable once MemberCanBeProtected.Global
    public ApiResult()
    {
            
    }

    public ApiResult(bool success)
    {
        Success = success;
    }
        
    // ReSharper disable once MemberCanBePrivate.Global
    public bool Success { get; set; } = true;
        
    // ReSharper disable once UnusedMember.Global
    public List<MessageInfo>? Errors { get; set; }
        
}